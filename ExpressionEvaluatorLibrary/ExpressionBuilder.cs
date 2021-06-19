using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

using ExpressionEvaluatorLibrary.ExpressionTree;
using ExpressionEvaluatorLibrary.Operators;

namespace ExpressionEvaluatorLibrary
{
  public interface IExpressionBuilder
  {
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

    public class UnrecognizedOperationException : BadInputException
    {
      public UnrecognizedOperationException()
      {
      }

      public UnrecognizedOperationException(string message) : base(message)
      {
      }

      public UnrecognizedOperationException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    public class UnrecognizedFunctionException : BadInputException
    {
      public UnrecognizedFunctionException()
      {
      }

      public UnrecognizedFunctionException(string message) : base(message)
      {
      }

      public UnrecognizedFunctionException(string message, Exception inner) : base(message, inner)
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

    public class UninitializedException : Exception
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

    private enum State
    {
      ExpectOperand,
      ExpectOperator
    };

    private static readonly Regex TokenRegex = new Regex(@"
      ^
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

    private ExpressionTree.Valuable _tree;
    private string _expression;
    private HashSet<string> _variables;

    public ExpressionBuilder(string expression)
    {
      expression = expression.Replace(" ", string.Empty).Trim();

      _expression = expression;

      // some code here
    }

    private ExpressionTree.Valuable ShuntingYard(string expression)
    {
      State state = State.ExpectOperand;
      Stack<ExpressionTree.Valuable> valst = new Stack<ExpressionTree.Valuable>();
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
            valst.Push(Factory.MakePositive(a[0]));
            break;

          case OperatorInfo.UnaryMinus:
            valst.Push(Factory.MakeNegative(a[0]));
            break;

          case OperatorInfo.Plus:
            valst.Push(Factory.MakeAddition(a[1], a[0]));
            break;

          case OperatorInfo.Minus:
            valst.Push(Factory.MakeSubtraction(a[1], a[0]));
            break;

          case OperatorInfo.Star:
            valst.Push(Factory.MakeMultiplication(a[1], a[0]));
            break;

          case OperatorInfo.Slash:
            valst.Push(Factory.MakeDivision(a[1], a[0]));
            break;

          case OperatorInfo.Hat:
            valst.Push(Factory.MakeExponentiation(a[1], a[0]));
            break;

          case OperatorInfo.SinFunction:
            valst.Push(Factory.MakeSinFunction(a[0]));
            break;

          case OperatorInfo.CosFunction:
            valst.Push(Factory.MakeCosFunction(a[0]));
            break;

          case OperatorInfo.TanFunction:
            valst.Push(Factory.MakeTanFunction(a[0]));
            break;

          case OperatorInfo.AsinFunction:
            valst.Push(Factory.MakeAsinFunction(a[0]));
            break;

          case OperatorInfo.AcosFunction:
            valst.Push(Factory.MakeAcosFunction(a[0]));
            break;

          case OperatorInfo.AtanFunction:
            valst.Push(Factory.MakeAtanFunction(a[0]));
            break;

          case OperatorInfo.ExpFunction:
            valst.Push(Factory.MakeExpFunction(a[0]));
            break;

          case OperatorInfo.LogFunction:
            valst.Push(Factory.MakeLogFunction(a[0]));
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
                throw new UnrecognizedFunctionException();

              string f = m.Groups["function"].Value;
              opst.Push(Helpers.GetFunction(f));
            }
            else if (m.Groups["operand"].Success)
            {
              if (m.Groups["constant"].Success)
              {
                try
                {
                  double c = Convert.ToDouble(m.Groups["constant"].Success);
                  valst.Push(Factory.MakeConstant(c));
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
                valst.Push(Factory.MakeVariable(v));
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

              while (opst.Count != 0)
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
            }
            else if (m.Groups["operator"].Success)
            {
              if (m.Groups["unrecognized"].Success)
                throw new UnrecognizedOperationException();

              string p = m.Groups["operator"].Value;
              OperatorInfo oc = Helpers.GetBinary(p);
              bool inorder = false;

              while (opst.Count != 0 && !inorder)
              {
                OperatorInfo os = opst.Peek();

                if (oc.GetPriority() > os.GetPriority() || oc.GetPriority() == os.GetPriority() && oc.GetAssociativity() == Associativity.Left)
                  dispatch();
                else
                  inorder = true;
              }

              opst.Push(oc);
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

    public double Evaluate(Context context)
    {
      if (_tree == null)
        throw new UninitializedException();

      return _tree.Evaluate(context);
    }
  }
}