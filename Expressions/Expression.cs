using Expressions.ExpressionTree;
using Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Expressions
{
  /// <summary>
  /// Represents a mathematical expression.
  /// </summary>
  public class Expression
  {
    private static readonly Regex TokenRegex;

    private string _expression;

    private int _position;

    private IValuable _tree;

    private HashSet<string> _variables;

    static Expression()
    {
      string specials = @"(?<comma>,)|(?<parenthesis>(?<leftp>\()|(?<rightp>\)))";

      string unariables = $@"(?<unariable>{
        string.Join("|",
        OperatorInfo.GetUnaryOperators().Select((op) => $"(?<{op.Name}>{Regex.Escape(op.Symbol)})")
        )})";

      string binaries = $@"{
        string.Join("|",
        OperatorInfo.GetBinaryOperators().Select((op) => $"(?<{op.Name}>{Regex.Escape(op.Symbol)})")
        )}";

      string operators = $@"(?<operator>{
        string.Join("|",
        unariables,
        binaries)})";

      string functions = $@"(?<function>{
        string.Join("|",
        string.Join("|",
        OperatorInfo.GetFunctions().Select((op) => $"(?<{op.Name}>{Regex.Escape(op.Symbol)})")
        ),
        "(?<unrecognized>[a-z_][a-z_0-9]*)"
        )})(?=\()";

      string operands = @"(?<operand>(?<constant>\d+(?:\.\d+)?)|(?<variable>[a-z_][a-z_0-9]*))";

      string token = $@"(?<token>{
        string.Join("|",
        specials,
        operators,
        functions,
        operands
        )})";

      TokenRegex = new Regex($@"^{token}\s*(?<subexpr>.*)$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    }

    /// <summary>
    /// Constructs an expression object from expression string.
    /// </summary>
    /// <param name="expression"></param>
    public Expression(string expression)
    {
      if (expression == null)
        throw new ArgumentNullException("The expression string cannot be null.");

      expression = expression.Trim();

      if (expression.Length == 0)
        throw new ArgumentException("No expression was given.");

      _expression = expression;
      _position = 0;
      _variables = new HashSet<string>();

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

      return
        $@"digraph
{{
labelloc=t
label=""{_expression}""
{Factory.GetListing(_tree)}
}}";
    }

    /// <summary>
    /// Returns a read-only collection of expression variables.
    /// </summary>
    /// <returns></returns>
    public IReadOnlyCollection<string> GetVariables()
    {
      if (_tree == null)
        throw new UninitializedException();

      return _variables.ToList().AsReadOnly();
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
        IValuable[] a = new IValuable[p.Arity];

        for (int i = p.Arity - 1; i >= 0; i--)
        {
          if (valst.Count != 0)
            a[i] = valst.Pop();
          else
            throw new MissingArgumentException();
        }

        if (p == OperatorInfo.LeftParenthesis)
          throw new MismatchedParenthesesException();

        if (p.OperatorType == OperatorType.Special)
          throw new CannotDispatchException();

        valst.Push(Factory.MakeFunction(p, a));
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
              opst.Push(OperatorInfo.GetUnary(p));
            }
            else if (m.Groups["function"].Success)
            {
              if (m.Groups["unrecognized"].Success)
                throw new UnsupportedFunctionException();

              string f = m.Groups["function"].Value;
              opst.Push(OperatorInfo.GetFunction(f));
            }
            else if (m.Groups["operand"].Success)
            {
              string o = m.Groups["operand"].Value;

              if (m.Groups["constant"].Success)
              {
                try
                {
                  double c = Convert.ToDouble(o);
                  valst.Push(Factory.MakeConstant(c));
                }
                catch (OverflowException)
                {
                  throw new BadValueException();
                }
              }
              else if (m.Groups["variable"].Success)
              {
                valst.Push(Factory.MakeVariable(o));
                _variables.Add(o);
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

              if (opst.Count != 0 && opst.Peek().OperatorType == OperatorType.Function)
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
              string p = m.Groups["operator"].Value;
              OperatorInfo oc = OperatorInfo.GetBinary(p);
              bool inorder = false;

              while (opst.Count != 0 && !inorder)
              {
                OperatorInfo os = opst.Peek();

                if (os.Priority != Priority.Primary && (oc.Priority > os.Priority || oc.Priority == os.Priority && oc.Associativity == Associativity.Left))
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