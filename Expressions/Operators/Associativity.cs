namespace Expressions.Operators
{
  /// <summary>
  /// Specifies the associativity of an operator
  /// </summary>
  internal enum Associativity : int
  {
    Left = 1,
    Right = -1,
    Undefined = 0,
  }
}