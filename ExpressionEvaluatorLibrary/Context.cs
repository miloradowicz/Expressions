using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  #region Read-Only Interface

  public interface IReadOnlyContext
  {
    /// <summary>
    /// The value of the specified variable.
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

  #endregion Read-Only Interface

  #region Read-Write Interface

  internal interface IContext : IReadOnlyContext
  {
    /// <summary>
    /// The value of the specified variable. If an unbound variable is being set, creates a binding.
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

  #endregion Read-Write Interface

  /// <summary>
  /// Describes bindings of expression variables to their corresponding values.
  /// </summary>
  public class Context : IContext
  {
    #region Exceptions

    public class UnboundVariableException : Exception
    {
      public UnboundVariableException()
      {
      }

      public UnboundVariableException(string message) : base(message)
      {
      }

      public UnboundVariableException(string message, Exception inner) : base(message, inner)
      {
      }
    }

    #endregion Exceptions

    #region Fields

    private readonly Dictionary<string, double> _context;

    #endregion Fields

    #region Constructors

    internal Context()
    {
      _context = new Dictionary<string, double>();
    }

    #endregion Constructors

    #region Public Properties

    public double this[string variable]
    {
      get
      {
        if (_context.ContainsKey(variable))
          return _context[variable];
        else
          throw new UnboundVariableException();
      }
      set
      {
        _context[variable] = value;
      }
    }

    #endregion Public Properties

    #region Public Methods

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

    #endregion Public Methods
  }

  /// <summary>
  /// Read-only wrapper aroung a context.
  /// </summary>
  public class ReadOnlyContext : IReadOnlyContext
  {
    #region Fields

    private readonly Context _context;

    #endregion Fields

    #region Constructors

    internal ReadOnlyContext(Context context)
    {
      _context = context;
    }

    #endregion Constructors

    #region Public Properties

    public double this[string variable] => _context[variable];

    #endregion Public Properties

    #region Public Methods

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

    #endregion Public Methods
  }
}