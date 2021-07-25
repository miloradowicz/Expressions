using System;

namespace Expressions.Operators
{
  /// <summary>
  /// Applies the category of type to an operator.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  internal class OperatorTypeAttribute : Attribute
  {
    /// <summary>
    /// Applies the specified type to an operator.
    /// </summary>
    /// <param name="type">The specified type</param>
    public OperatorTypeAttribute(OperatorType type) => OperatorType = type;

    /// <summary>
    /// Gets the operator type.
    /// </summary>
    public OperatorType OperatorType { get; private set; }
  }
}