using ExpressionEvaluatorLibrary.ExpressionTree;
using ExpressionEvaluatorLibrary.Operators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExpressionEvaluatorLibrary
{
  public interface IExpressionBuilder
  {
    IReadOnlyCollection<string> GetVariables();

    double Evaluate(IReadOnlyContext context);

    double Solve(IReadOnlyContext context, string unknown, double guess, double error, int steps);

    string GetListing();
  }

  public class ExpressionBuilder : IExpressionBuilder
  {
    public class BadInputException : Exception
    {
      public BadInputException()
      {
      }

      public BadInputException(string message) : base(message)
      {
      }

      public BadInputException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class BadSyntaxException : Exception
    {
      public BadSyntaxException()
      {
      }

      public BadSyntaxException(string message) : base(message)
      {
      }

      public BadSyntaxException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class RuntimeException : Exception
    {
      public RuntimeException()
      {
      }

      public RuntimeException(string message) : base(message)
      {
      }

      public RuntimeException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class SolveException : Exception
    {
      public SolveException()
      {
      }

      public SolveException(string message) : base(message)
      {
      }

      public SolveException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class EmptyExpressionException : Exception
    {
      public EmptyExpressionException()
      {
      }

      public EmptyExpressionException(string message) : base(message)
      {
      }

      public EmptyExpressionException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UnrecognizedSymbolException : BadInputException
    {
      public UnrecognizedSymbolException()
      {
      }

      public UnrecognizedSymbolException(string message) : base(message)
      {
      }

      public UnrecognizedSymbolException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class BadValueException : BadInputException
    {
      public BadValueException()
      {
      }

      public BadValueException(string message) : base(message)
      {
      }

      public BadValueException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UnsupportedOperationException : BadInputException
    {
      public UnsupportedOperationException()
      {
      }

      public UnsupportedOperationException(string message) : base(message)
      {
      }

      public UnsupportedOperationException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UnsupportedFunctionException : BadInputException
    {
      public UnsupportedFunctionException()
      {
      }

      public UnsupportedFunctionException(string message) : base(message)
      {
      }

      public UnsupportedFunctionException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class OperandExpectedExcpetion : BadSyntaxException
    {
      public OperandExpectedExcpetion()
      {
      }

      public OperandExpectedExcpetion(string message) : base(message)
      {
      }

      public OperandExpectedExcpetion(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class OperatorExpectedException : BadSyntaxException
    {
      public OperatorExpectedException()
      {
      }

      public OperatorExpectedException(string message) : base(message)
      {
      }

      public OperatorExpectedException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class MissingArgumentException : BadSyntaxException
    {
      public MissingArgumentException()
      {
      }

      public MissingArgumentException(string message) : base(message)
      {
      }

      public MissingArgumentException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class TooManyArgumentsException : BadSyntaxException
    {
      public TooManyArgumentsException()
      {
      }

      public TooManyArgumentsException(string message) : base(message)
      {
      }

      public TooManyArgumentsException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class CannotDispatchException : BadSyntaxException
    {
      public CannotDispatchException()
      {
      }

      public CannotDispatchException(string message) : base(message)
      {
      }

      public CannotDispatchException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class MismatchedParenthesesException : BadSyntaxException
    {
      public MismatchedParenthesesException()
      {
      }

      public MismatchedParenthesesException(string message) : base(message)
      {
      }

      public MismatchedParenthesesException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UninitializedException : RuntimeException
    {
      public UninitializedException()
      {
      }

      public UninitializedException(string message) : base(message)
      {
      }

      public UninitializedException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UnboundVariableException : RuntimeException
    {
      public UnboundVariableException()
      {
      }

      public UnboundVariableException(string message) : base(message)
      {
      }

      public UnboundVariableException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class InvalidVariableException : RuntimeException
    {
      public InvalidVariableException()
      {
      }

      public InvalidVariableException(string message) : base(message)
      {
      }

      public InvalidVariableException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class InvalidConstraintException : SolveException
    {
      public InvalidConstraintException()
      {
      }

      public InvalidConstraintException(string message) : base(message)
      {
      }

      public InvalidConstraintException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class CouldNotSolveException : SolveException
    {
      public CouldNotSolveException()
      {
      }

      public CouldNotSolveException(string message) : base(message)
      {
      }

      public CouldNotSolveException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    private enum State
    {
      ExpectOperand,
      ExpectOperator
    };

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

    static public Context CreateContext()
    {
      return new Context();
    }

    private string _expression;
    private Valuable _tree;
    private Factory _factory;
    private HashSet<string> _variables;

    public ExpressionBuilder(string expression)
    {
      expression = expression.Trim();

      if (expression.Length == 0)
        throw new EmptyExpressionException();

      _expression = expression;
      _factory = new Factory();
      _variables = new HashSet<string>();

      _tree = ShuntingYard(expression);
    }

    private Valuable ShuntingYard(string expression)
    {
      State state = State.ExpectOperand;
      Stack<Valuable> valst = new Stack<Valuable>();
      Stack<OperatorInfo> opst = new Stack<OperatorInfo>();
      Match m;
      string s = expression;

      Action dispatch = () =>
      {
        OperatorInfo p = opst.Pop();
        List<Valuable> a = new List<Valuable>();

        for (int i = 0; i < p.GetArity(); i++)
        {
          if (valst.Count != 0)
            a.Add(valst.Pop());
          else
            throw new MissingArgumentException();
        }

        switch (p)
        {
          case OperatorInfo.UnaryPlus:
            valst.Push(_factory.MakePositive(a[0]));
            break;

          case OperatorInfo.UnaryMinus:
            valst.Push(_factory.MakeNegative(a[0]));
            break;

          case OperatorInfo.Plus:
            valst.Push(_factory.MakeAddition(a[1], a[0]));
            break;

          case OperatorInfo.Minus:
            valst.Push(_factory.MakeSubtraction(a[1], a[0]));
            break;

          case OperatorInfo.Star:
            valst.Push(_factory.MakeMultiplication(a[1], a[0]));
            break;

          case OperatorInfo.Slash:
            valst.Push(_factory.MakeDivision(a[1], a[0]));
            break;

          case OperatorInfo.Hat:
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
              opst.Push(Helpers.GetUnary(p));
            }
            else if (m.Groups["function"].Success)
            {
              if (m.Groups["unrecognized"].Success)
                throw new UnsupportedFunctionException();

              string f = m.Groups["function"].Value;
              opst.Push(Helpers.GetFunction(f));
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
                _variables.Add(v);
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
              OperatorInfo oc = Helpers.GetBinary(p);
              bool inorder = false;

              while (opst.Count != 0 && !inorder)
              {
                OperatorInfo os = opst.Peek();

                if (os.GetPriority() != PriorityGroup.Primary && (oc.GetPriority() > os.GetPriority() || oc.GetPriority() == os.GetPriority() && oc.GetAssociativity() == Associativity.Left))
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

    private double Steffensen(Dictionary<double, double> memo, IContext context, string unknown, double error, int steps)
    {
      if (steps <= 0)
        throw new CouldNotSolveException();

      double x, fx, gx, xn, fxn;
      x = context[unknown];
      if (memo.ContainsKey(x))
      {
        fx = memo[x];
      }
      else
      {
        fx = _tree.Evaluate(context);
        memo[x] = fx;
      }

      if (Math.Abs(fx) < error)
        return x;

      context[unknown] = x + fx;
      gx = _tree.Evaluate(context) / fx - 1;
      xn = x - fx / gx;
      context[unknown] = xn;
      fxn = _tree.Evaluate(context);
      memo[xn] = fxn;
      return Steffensen(memo, context, unknown, error, steps - 1);
    }

    public IReadOnlyCollection<string> GetVariables()
    {
      if (_tree == null)
        throw new UninitializedException();

      return _variables.AsReadOnly<string>();
    }

    public double Evaluate(IReadOnlyContext context)
    {
      if (_tree == null)
        throw new UninitializedException();

      foreach (string s in _variables)
      {
        if (!context.IsBound(s))
          throw new UnboundVariableException();
      }

      return _tree.Evaluate(context);
    }

    public double Solve(IReadOnlyContext context, string unknown, double guess, double error, int steps)
    {
      if (!_variables.Contains(unknown))
        throw new InvalidVariableException();

      foreach (string v in _variables)
      {
        if (!context.IsBound(v) && v != unknown)
          throw new UnboundVariableException();
      }

      if (error <= 0 || steps <= 0)
        throw new InvalidConstraintException();

      Dictionary<double, double> memo = new Dictionary<double, double>();
      Context clonetext = context.Clone();
      clonetext[unknown] = guess;

      return Steffensen(memo, clonetext, unknown, error, steps);
    }

    public string GetListing()
    {
      if (_tree == null)
        throw new UninitializedException();

      return $"strict graph {{{_factory.GetListing()}}}";
    }
  }
}