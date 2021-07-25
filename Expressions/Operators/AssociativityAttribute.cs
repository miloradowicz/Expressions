using System;

namespace Expressions.Operators
{
  /// <summary>
  /// Applies the category of associativity to an operator.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  internal class AssociativityAttribute : Attribute
  {
    /// <summary>
    /// Applies the specified associativity to an operator.
    /// </summary>
    /// <param name="associativity">The specified associativity</param>
    public AssociativityAttribute(Associativity associativity) => Associativity = associativity;

    /// <summary>
    /// Gets the operator associativity.
    /// </summary>
    public Associativity Associativity { get; private set; }
  }
}