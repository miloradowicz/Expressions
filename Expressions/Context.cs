using System;
using System.Collections.Generic;

namespace Expressions
{
  /// <summary>
  /// Describes bindings of expression variables to their corresponding values.
  /// </summary>
  public class Context : IContext
  {
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
      get
      {
        if (_context.ContainsKey(variable))
          return _context[variable];
        else
          throw new InvalidOperationException("The specified variable is not bound in this context.");
      }
      set
      {
        _context[variable] = value;
      }
    }

    public IReadOnlyContext AsReadOnly()
    {
      return new ReadOnlyContext(this);
    }

    public void Bind(string variable, double value)
    {
      _context[variable] = value;
    }

    public Context Clone()
    {
      Context c = new Context();
      foreach (var v in _context)
        c._context.Add(v.Key, v.Value);
      return c;
    }

    public IReadOnlyCollection<string> GetBoundVariables()
    {
      return _context.Keys;
    }

    public bool IsBound(string variable)
    {
      return _context.ContainsKey(variable);
    }

    public void Unbind(string variable)
    {
      _context.Remove(variable);
    }

    internal bool ContainsKey(string variable)
    {
      throw new NotImplementedException();
    }
  }
}