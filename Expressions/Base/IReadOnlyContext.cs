using System.Collections.Generic;

namespace Expressions
{
  public interface IReadOnlyContext
  {
    /// <summary>
    /// Gets the value of the specified variable.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    /// <returns></returns>
    double this[string variable] { get; }

    /// <summary>
    /// Returns a copy of the context.
    /// </summary>
    /// <returns></returns>
    Context Clone();

    /// <summary>
    /// Returns the value of the specified variable.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    /// <returns></returns>
    double Get(string variable);

    /// <summary>
    /// Returns a read-only collection of all bound variables.
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<string> GetBoundVariables();

    /// <summary>
    /// Checks if the variable is bound.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    /// <returns></returns>
    bool IsBound(string variable);
  }
}