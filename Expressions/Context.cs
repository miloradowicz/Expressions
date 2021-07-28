using System;
using System.Collections.Generic;

namespace Expressions
{
  /// <summary>
  /// Describes bindings of expression variables to their corresponding values.
  /// </summary>
  public class Context : IContext
  {
    private static readonly Dictionary<string, double> constants = new Dictionary<string, double>()
    {
      #region Named Constants

      { "pi", Math.PI },

      #endregion Named Constants
    };

    private readonly Dictionary<string, double> _context;

    /// <summary>
    /// Creates an empty context.
    /// </summary>
    /// <returns></returns>
    public Context()
    {
      _context = new Dictionary<string, double>();
    }

    public double this[string variable]
    {
      get => Get(variable);
      set => Bind(variable, value);
    }

    public IReadOnlyContext AsReadOnly()
    {
      return new ReadOnlyContext(this);
    }

    public void Bind(string variable, double value)
    {
      if (constants.ContainsKey(variable))
        throw new InvalidOperationException("Cannot reassign predefined constant.");

      _context[variable] = value;
    }

    public Context Clone()
    {
      Context c = new Context();
      foreach (var v in _context)
        c._context.Add(v.Key, v.Value);
      return c;
    }

    public double Get(string variable)
    {
      if (constants.ContainsKey(variable))
        return constants[variable];

      if (_context.ContainsKey(variable))
        return _context[variable];
      else
        throw new InvalidOperationException("The specified variable is not bound in this context.");
    }

    public IReadOnlyCollection<string> GetBoundVariables()
    {
      return _context.Keys;
    }

    public bool IsBound(string variable)
    {
      return constants.ContainsKey(variable) || _context.ContainsKey(variable);
    }

    public void Unbind(string variable)
    {
      _context.Remove(variable);
    }
  }
}