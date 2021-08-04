using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Expressions.Operators
{
  // This class among other purposes defines all supported operators and functions.
  // To add a new function add another static field and instantiate an OperatorInfo object and specify its attributes,
  // such as its priority, associativity and arity, as well as define the action that corresponds to the operator or function in question.
  // Refer to the constructor summary to the constructor to get more info.

  /// <summary>
  /// Represents algebraic syntax tokens
  /// </summary>
  internal class OperatorInfo
  {
    #region Special

    public static OperatorInfo Comma = new OperatorInfo(",", OperatorType.Special, Priority.Primary, Associativity.Left, 0, null, "comma");
    public static OperatorInfo LeftParenthesis = new OperatorInfo("(", OperatorType.Special, Priority.Primary, Associativity.Left, 0, null, "leftp");
    public static OperatorInfo RightParenthesis = new OperatorInfo(")", OperatorType.Special, Priority.Primary, Associativity.Left, 0, null, "rightp");

    #endregion Special

    #region Functions

    public static OperatorInfo AbsFunction = new OperatorInfo("abs", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Abs);
    public static OperatorInfo AcosFunction = new OperatorInfo("acos", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Acos);
    public static OperatorInfo AsinFunction = new OperatorInfo("asin", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Asin);
    public static OperatorInfo AtanFunction = new OperatorInfo("atan", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Atan);
    public static OperatorInfo CosFunction = new OperatorInfo("cos", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Cos);
    public static OperatorInfo CoshFunction = new OperatorInfo("cosh", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Cosh);
    public static OperatorInfo ExpFunction = new OperatorInfo("exp", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Exp);
    public static OperatorInfo LogFunction = new OperatorInfo("log", OperatorType.Function, Priority.Primary, Associativity.Left, 2, (Func<double, double, double>)Math.Log);
    public static OperatorInfo LognFunction = new OperatorInfo("logn", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Log);
    public static OperatorInfo PowFunction = new OperatorInfo("pow", OperatorType.Function, Priority.Primary, Associativity.Left, 2, (Func<double, double, double>)Math.Pow);
    public static OperatorInfo SinFunction = new OperatorInfo("sin", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Sin);
    public static OperatorInfo SinhFunction = new OperatorInfo("sinh", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Sinh);
    public static OperatorInfo SqrtFunction = new OperatorInfo("sqrt", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Sqrt);
    public static OperatorInfo TanFunction = new OperatorInfo("tan", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Tan);
    public static OperatorInfo TanhFunction = new OperatorInfo("tanh", OperatorType.Function, Priority.Primary, Associativity.Left, 1, (Func<double, double>)Math.Tanh);

    #endregion Functions

    #region Operators

    public static OperatorInfo HatOperator = new OperatorInfo("^", OperatorType.Operator, Priority.Exponentiative, Associativity.Left, 2, (Func<double, double, double>)Math.Pow, "hat");
    public static OperatorInfo MinusOperator = new OperatorInfo("-", OperatorType.Operator, Priority.Additive, Associativity.Left, 2, (Func<double, double, double>)((x, y) => x - y), "minus");
    public static OperatorInfo PercentOperator = new OperatorInfo("%", OperatorType.Operator, Priority.Multiplicative, Associativity.Left, 2, (Func<double, double, double>)((x, y) => x % y), "percent");
    public static OperatorInfo PlusOperator = new OperatorInfo("+", OperatorType.Operator, Priority.Additive, Associativity.Left, 2, (Func<double, double, double>)((x, y) => x + y), "plus");
    public static OperatorInfo SlashOperator = new OperatorInfo("/", OperatorType.Operator, Priority.Multiplicative, Associativity.Left, 2, (Func<double, double, double>)((x, y) => x / y), "slash");
    public static OperatorInfo StarOperator = new OperatorInfo("*", OperatorType.Operator, Priority.Multiplicative, Associativity.Left, 2, (Func<double, double, double>)((x, y) => x * y), "star");
    public static OperatorInfo UnaryMinusOperator = new OperatorInfo("-", OperatorType.Operator, Priority.Unary, Associativity.Left, 1, (Func<double, double>)((x) => -x), "minus");
    public static OperatorInfo UnaryPlusOperator = new OperatorInfo("+", OperatorType.Operator, Priority.Unary, Associativity.Left, 1, (Func<double, double>)((x) => x), "plus");

    #endregion Operators

    private static List<OperatorInfo> operators;

    private static Dictionary<string, List<OperatorInfo>> symbols;

    static OperatorInfo()
    {
      operators = new List<OperatorInfo>();
      symbols = new Dictionary<string, List<OperatorInfo>>();

      var fields = typeof(OperatorInfo).GetFields(BindingFlags.Public | BindingFlags.Static);

      foreach (var f in fields)
      {
        var op = (OperatorInfo)f.GetValue(null);
        var symbol = op.Symbol;

        operators.Add(op);

        if (symbols.ContainsKey(symbol))
          symbols[symbol].Add(op);
        else
          symbols[symbol] = new List<OperatorInfo> { op };
      }
    }

    /// <summary>
    /// Constructs an instance to represent a syntax token
    /// </summary>
    /// <param name="symbol">The symbol of the token as it would appear in an expression string</param>
    /// <param name="type">The type of the token</param>
    /// <param name="priority">The priority group of an operator. Should be Primary for everything else</param>
    /// <param name="associativity">The associativity of an operator. Should be left for everything else</param>
    /// <param name="arity">The arity of an operator or a function</param>
    /// <param name="delegate">A delegate that represents the action of an operator or a function</param>
    /// <param name="name">A friendly name for the token</param>
    private OperatorInfo(string symbol, OperatorType type, Priority priority, Associativity associativity, int arity, Delegate @delegate, string name = null)
    {
      Symbol = symbol;
      OperatorType = type;
      Priority = priority;
      Associativity = associativity;
      Arity = arity;
      Delegate = @delegate;
      Name = name ?? symbol;
    }

    public int Arity { get; private set; }

    public Associativity Associativity { get; private set; }

    public Delegate Delegate { get; private set; }

    public string Name { get; private set; }

    public OperatorType OperatorType { get; private set; }

    public Priority Priority { get; private set; }

    public string Symbol { get; private set; }

    public static OperatorInfo GetBinary(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.OperatorType == OperatorType.Operator && op.Arity == 2);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    public static IEnumerable<OperatorInfo> GetBinaryOperators()
    {
      foreach (var op in operators)
      {
        if (op.OperatorType == OperatorType.Operator && op.Arity == 2)
          yield return op;
      }
    }

    public static OperatorInfo GetFunction(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.OperatorType == OperatorType.Function);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    public static IEnumerable<OperatorInfo> GetFunctions()
    {
      foreach (var op in operators)
      {
        if (op.OperatorType == OperatorType.Function)
          yield return op;
      }
    }

    public static OperatorInfo GetNamedConstant(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.OperatorType == OperatorType.NamedConstant);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    public static IEnumerable<OperatorInfo> GetOperators()
    {
      foreach (var op in operators)
      {
        if (op.OperatorType == OperatorType.Operator)
          yield return op;
      }
    }

    public static OperatorInfo GetSpecial(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.OperatorType == OperatorType.Special);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    public static OperatorInfo GetUnary(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.OperatorType == OperatorType.Operator && op.Arity == 1);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    public static IEnumerable<OperatorInfo> GetUnaryOperators()
    {
      foreach (var op in operators)
      {
        if (op.OperatorType == OperatorType.Operator && op.Arity == 1)
          yield return op;
      }
    }
  }
}