namespace Expressions.Operators
{
  /// <summary>
  /// Represents operators
  /// </summary>
  internal enum OperatorInfo
  {
    #region Special

    [Symbol("("), OperatorType(OperatorType.Special), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(0)]
    LeftParenthesis,

    //[Symbol(")"), OperatorType(OperatorType.Special), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(0)]
    //RightParenthesis,

    //[Symbol(","), OperatorType(OperatorType.Special), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(0)]
    //Comma,

    #endregion Special

    #region Named Constants

    [Symbol("pi"), OperatorType(OperatorType.NamedConstant), Priority(Priority.Primary), Associativity(Associativity.Undefined), Arity(0)]
    PiConstant,

    #endregion Named Constants

    #region Functions

    [Symbol("sin"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    SinFunction,

    [Symbol("cos"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    CosFunction,

    [Symbol("tan"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    TanFunction,

    [Symbol("asin"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    AsinFunction,

    [Symbol("acos"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    AcosFunction,

    [Symbol("atan"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    AtanFunction,

    [Symbol("exp"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    ExpFunction,

    [Symbol("log"), OperatorType(OperatorType.Function), Priority(Priority.Primary), Associativity(Associativity.Left), Arity(1)]
    LogFunction,

    #endregion Functions

    #region Operators

    [Symbol("+"), OperatorType(OperatorType.Operator), Priority(Priority.Unary), Associativity(Associativity.Left), Arity(1)]
    UnaryPlusOperator,

    [Symbol("-"), OperatorType(OperatorType.Operator), Priority(Priority.Unary), Associativity(Associativity.Left), Arity(1)]
    UnaryMinusOperator,

    [Symbol("^"), OperatorType(OperatorType.Operator), Priority(Priority.Exponentiative), Associativity(Associativity.Right), Arity(2)]
    HatOperator,

    [Symbol("*"), OperatorType(OperatorType.Operator), Priority(Priority.Multiplicative), Associativity(Associativity.Left), Arity(2)]
    StarOperator,

    [Symbol("/"), OperatorType(OperatorType.Operator), Priority(Priority.Multiplicative), Associativity(Associativity.Left), Arity(2)]
    SlashOperator,

    [Symbol("+"), OperatorType(OperatorType.Operator), Priority(Priority.Additive), Associativity(Associativity.Left), Arity(2)]
    PlusOperator,

    [Symbol("-"), OperatorType(OperatorType.Operator), Priority(Priority.Additive), Associativity(Associativity.Left), Arity(2)]
    MinusOperator,

    #endregion Operators
  }
}