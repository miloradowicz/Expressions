using Expressions.ExpressionTree;
using Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Expressions
{
  /// <summary>
  /// Represents a mathematical expression.
  /// </summary>
  public class ExpressionBuilder
  {
    private static readonly Regex TokenRegex = new Regex(@"
      ^\s*
      (?<token>
        (?<comma>,) |
        (?<parenthesis>
          (?<leftp>\() |
          (?<rightp>\))
        ) |
        (?<operator>
          (?<unariable>
            (?<plus>\+) |
            (?<minus>-)
          ) |
          (?<star>\*) |
          (?<slash>/) |
          (?<hat>\^) |
          (?<unrecognized>[~!&|=<>%:\\])
        ) |
        (?<function>
          (?<sin>sin) |
          (?<cos>cos) |
          (?<tan>tan) |
          (?<asin>asin) |
          (?<acos>acos) |
          (?<atan>atan) |
          (?<log>log) |
          (?<exp>exp) |
          (?<unrecognized>[a-z_][a-z_0-9]*)
        )(?=\() |
        (?<operand>
          (?<constant>\d+(?:\.\d+)?) |
          (?<variable>[a-z_][a-z_0-9]*)
        )
      )
      (?<subexpr>.*)
      $
      ", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    private string _expression;
    private Factory _factory;
    private IValuable _tree;

    /// <summary>
    /// Constructs an expression object from expression string.
    /// </summary>
    /// <param name="expression"></param>
    public ExpressionBuilder(string expression)
    {
      expression = expression.Trim();

      if (expression.Length == 0)
        throw new EmptyExpressionException();

      _expression = expression;
      _factory = new Factory();

      _tree = ShuntingYard(expression);
    }

    private enum State
    {
      ExpectOperand,
      ExpectOperator
    };

    /// <summary>
    /// Evaluates the expression for the specified context.
    /// </summary>
    /// <param name="context">The context the expression is to be evaluated for</param>
    /// <returns></returns>
    public double Evaluate(IReadOnlyContext context)
    {
      var variables = GetVariables();

      foreach (string s in variables)
      {
        if (!context.IsBound(s))
          throw new UnboundVariableException();
      }

      return _tree.Evaluate(context);
    }

    /// <summary>
    /// Returns the expression tree listing in the DOT language.
    /// </summary>
    /// <returns></returns>
    public string GetListing()
    {
      if (_tree == null)
        throw new UninitializedException();

      return $"strict graph {{{_factory.GetListing()}}}";
    }

    /// <summary>
    /// Returns a read-only collection of expression variables.
    /// </summary>
    /// <returns></returns>
    public IReadOnlyCollection<string> GetVariables()
    {
      if (_tree == null)
        throw new UninitializedException();

      return _factory.GetVariables();
    }

    /// <summary>
    /// Finds a zero of the expression.
    /// </summary>
    /// <param name="context">The context that defines bound variables</param>
    /// <param name="unknown">The name of the free variable</param>
    /// <param name="guess">The initial guess</param>
    /// <param name="error">The desired precision</param>
    /// <param name="steps">The number of iterations</param>
    /// <returns></returns>
    public double Solve(IReadOnlyContext context, string unknown, double guess, double error, int steps)
    {
      var variables = GetVariables();
      bool found = false;

      foreach (string v in variables)
      {
        if (v == unknown)
          found = true;
        else if (!context.IsBound(v))
          throw new UnboundVariableException();
      }

      if (!found)
        throw new InvalidVariableException();

      if (error <= 0 || steps <= 0)
        throw new InvalidConstraintException();

      Context clonetext = context.Clone();
      clonetext[unknown] = guess;

      return Steffensen(clonetext, unknown, error, steps);
    }

    private IValuable ShuntingYard(string expression)
    {
      State state = State.ExpectOperand;
      Stack<IValuable> valst = new Stack<IValuable>();
      Stack<OperatorInfo> opst = new Stack<OperatorInfo>();
      Match m;
      string s = expression;

      Action dispatch = () =>
      {
        OperatorInfo p = opst.Pop();
        List<IValuable> a = new List<IValuable>();

        for (int i = 0; i < p.GetArity(); i++)
        {
          if (valst.Count != 0)
            a.Add(valst.Pop());
          else
            throw new MissingArgumentException();
        }

        switch (p)
        {
          case OperatorInfo.UnaryPlusOperator:
            valst.Push(_factory.MakePositive(a[0]));
            break;

          case OperatorInfo.UnaryMinusOperator:
            valst.Push(_factory.MakeNegative(a[0]));
            break;

          case OperatorInfo.PlusOperator:
            valst.Push(_factory.MakeAddition(a[1], a[0]));
            break;

          case OperatorInfo.MinusOperator:
            valst.Push(_factory.MakeSubtraction(a[1], a[0]));
            break;

          case OperatorInfo.StarOperator:
            valst.Push(_factory.MakeMultiplication(a[1], a[0]));
            break;

          case OperatorInfo.SlashOperator:
            valst.Push(_factory.MakeDivision(a[1], a[0]));
            break;

          case OperatorInfo.HatOperator:
            valst.Push(_factory.MakeExponentiation(a[1], a[0]));
            break;

          case OperatorInfo.SinFunction:
            valst.Push(_factory.MakeSinFunction(a[0]));
            break;

          case OperatorInfo.CosFunction:
            valst.Push(_factory.MakeCosFunction(a[0]));
            break;

          case OperatorInfo.TanFunction:
            valst.Push(_factory.MakeTanFunction(a[0]));
            break;

          case OperatorInfo.AsinFunction:
            valst.Push(_factory.MakeAsinFunction(a[0]));
            break;

          case OperatorInfo.AcosFunction:
            valst.Push(_factory.MakeAcosFunction(a[0]));
            break;

          case OperatorInfo.AtanFunction:
            valst.Push(_factory.MakeAtanFunction(a[0]));
            break;

          case OperatorInfo.ExpFunction:
            valst.Push(_factory.MakeExpFunction(a[0]));
            break;

          case OperatorInfo.LogFunction:
            valst.Push(_factory.MakeLogFunction(a[0]));
            break;

          case OperatorInfo.LeftParenthesis:
            throw new MismatchedParenthesesException();

          default:
            throw new CannotDispatchException();
        }
      };

      while ((m = TokenRegex.Match(s)).Success)
      {
        s = m.Groups["subexpr"].Value;

        switch (state)
        {
          case State.ExpectOperand:
            if (m.Groups["leftp"].Success)
            {
              opst.Push(OperatorInfo.LeftParenthesis);
            }
            else if (m.Groups["unariable"].Success)
            {
              string p = m.Groups["unariable"].Value;
              opst.Push(Helpers.FindUnary(p));
            }
            else if (m.Groups["function"].Success)
            {
              if (m.Groups["unrecognized"].Success)
                throw new UnsupportedFunctionException();

              string f = m.Groups["function"].Value;
              opst.Push(Helpers.FindFunction(f));
            }
            else if (m.Groups["operand"].Success)
            {
              if (m.Groups["constant"].Success)
              {
                try
                {
                  double c = Convert.ToDouble(m.Groups["constant"].Value);
                  valst.Push(_factory.MakeConstant(c));
                }
                catch (OverflowException)
                {
                  throw new BadValueException();
                }
              }
              else if (m.Groups["variable"].Success)
              {
                string v = m.Groups["variable"].Value;
                valst.Push(_factory.MakeVariable(v));
              }

              state = State.ExpectOperator;
            }
            else
            {
              throw new OperandExpectedExcpetion();
            }
            break;

          case State.ExpectOperator:
            if (m.Groups["rightp"].Success)
            {
              bool matched = false;

              while (opst.Count != 0 && !matched)
              {
                if (opst.Peek() != OperatorInfo.LeftParenthesis)
                  dispatch();
                else
                  matched = true;
              }

              if (!matched)
                throw new MismatchedParenthesesException();

              opst.Pop();

              if (opst.Count != 0 && opst.Peek().GetOperatorType() == OperatorType.Function)
                dispatch();
            }
            else if (m.Groups["comma"].Success)
            {
              bool matched = false;

              while (opst.Count != 0 && !matched)
              {
                if (opst.Peek() != OperatorInfo.LeftParenthesis)
                  dispatch();
                else
                  matched = true;
              }

              if (!matched)
                throw new MismatchedParenthesesException();

              state = State.ExpectOperand;
            }
            else if (m.Groups["operator"].Success)
            {
              if (m.Groups["unrecognized"].Success)
                throw new UnsupportedOperationException();

              string p = m.Groups["operator"].Value;
              OperatorInfo oc = Helpers.FindBinary(p);
              bool inorder = false;

              while (opst.Count != 0 && !inorder)
              {
                OperatorInfo os = opst.Peek();

                if (os.GetPriority() != Priority.Primary && (oc.GetPriority() > os.GetPriority() || oc.GetPriority() == os.GetPriority() && oc.GetAssociativity() == Associativity.Left))
                  dispatch();
                else
                  inorder = true;
              }

              opst.Push(oc);

              state = State.ExpectOperand;
            }
            else
            {
              throw new OperatorExpectedException();
            }
            break;
        }
      }

      if (s.Length != 0)
        throw new UnrecognizedSymbolException();

      while (opst.Count != 0)
        dispatch();

      if (valst.Count == 0)
        throw new MissingArgumentException();
      else if (valst.Count != 1)
        throw new TooManyArgumentsException();

      return valst.Pop();
    }

    private double Steffensen(IContext context, string unknown, double error, int steps)
    {
      int n = steps;
      bool solved = false;
      double fx, gx;

      while (!solved && n > 0)
      {
        fx = _tree.Evaluate(context);

        if (Math.Abs(fx) < error)
        {
          solved = true;
        }
        else
        {
          context[unknown] += fx;
          gx = _tree.Evaluate(context) / fx - 1;
          context[unknown] -= fx / gx;
          n--;
        }
      }

      if (!solved)
        throw new CouldNotSolveException();

      return context[unknown];
    }
  }
}