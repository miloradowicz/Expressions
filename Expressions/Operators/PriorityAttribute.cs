using System;

namespace Expressions.Operators
{
  /// <summary>
  /// Applies the category of priority to an operator.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  internal class PriorityAttribute : Attribute
  {
    /// <summary>
    /// Applies the specified priority to an operator.
    /// </summary>
    /// <param name="priority">The specified priority</param>
    public PriorityAttribute(Priority priority) => Priority = priority;

    /// <summary>
    /// Gets the operator priority.
    /// </summary>
    public Priority Priority { get; private set; }
  }
}