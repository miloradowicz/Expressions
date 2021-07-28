namespace Expressions
{
  internal interface IContext : IReadOnlyContext
  {
    /// <summary>
    /// Gets or sets the value of the specified variable. If an unbound variable is being set, creates a binding.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    /// <returns></returns>
    new double this[string variable] { get; set; }

    /// <summary>
    /// Returns a read-only version of the context.
    /// </summary>
    /// <returns></returns>
    IReadOnlyContext AsReadOnly();

    /// <summary>
    /// Binds the specified variable.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    /// <param name="value">The value to assign</param>
    void Bind(string variable, double value);

    /// <summary>
    /// Unbinds the specified variable.
    /// </summary>
    /// <param name="variable">The name of the variable</param>
    void Unbind(string variable);
  }
}