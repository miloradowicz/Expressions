using System;
using System.Collections.Generic;

namespace Expressions
{
  /// <summary>
  /// Read-only wrapper aroung a context.
  /// </summary>
  public class ReadOnlyContext : IReadOnlyContext
  {
    private readonly Context _context;

    internal ReadOnlyContext(Context context)
    {
      _context = context;
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
    }

    public Context Clone()
    {
      return _context.Clone();
    }

    public IReadOnlyCollection<string> GetBoundVariables()
    {
      return _context.GetBoundVariables();
    }

    public bool IsBound(string variable)
    {
      return _context.IsBound(variable);
    }
  }
}