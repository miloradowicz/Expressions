using System;

namespace Expressions.Operators
{
  /// <summary>
  /// Applies the category of arity to an operator.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  internal class ArityAttribute : Attribute
  {
    /// <summary>
    /// Applies the specified arity to an operator.
    /// </summary>
    /// <param name="arity">The specified arity</param>
    public ArityAttribute(int arity) => Arity = arity;

    /// <summary>
    /// Gets the operator arity.
    /// </summary>
    public int Arity { get; private set; }
  }
}