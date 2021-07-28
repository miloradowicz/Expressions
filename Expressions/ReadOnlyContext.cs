using System.Collections.Generic;

namespace Expressions
{
  /// <summary>
  /// Read-only wrapper aroung a context.
  /// </summary>
  public class ReadOnlyContext : IReadOnlyContext
  {
    private readonly Context _context;

    internal ReadOnlyContext(Context context) => _context = context;

    public double this[string variable] => _context[variable];

    public Context Clone() => _context.Clone();

    public double Get(string variable) => _context.Get(variable);

    public IReadOnlyCollection<string> GetBoundVariables() => _context.GetBoundVariables();

    public bool IsBound(string variable) => _context.IsBound(variable);
  }
}