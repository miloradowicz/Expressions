using System;

namespace Expressions.Operators
{
  /// <summary>
  /// Specifies the symbolic designation of an operator.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  internal class SymbolAttribute : Attribute
  {
    /// <summary>
    /// Specifies the symbolic designation of an operator.
    /// </summary>
    /// <param name="symbol">The specified symbolic designation</param>
    public SymbolAttribute(string symbol) => Symbol = symbol;

    /// <summary>
    /// Gets the operator symbolic designation.
    /// </summary>
    public string Symbol { get; private set; }
  }
}