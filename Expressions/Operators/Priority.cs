namespace Expressions.Operators
{
  /// <summary>
  /// Specifies the priority of an operator
  /// </summary>
  internal enum Priority : int
  {
    Primary = 0,
    Unary = 1,
    Exponentiative = 2,
    Multiplicative = 3,
    Additive = 4,
  }
}