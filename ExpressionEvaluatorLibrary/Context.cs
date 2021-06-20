using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  internal interface IContext
  {
    double this[string variable] { get; set; }

    bool IsBound(string variable);

    void Bind(string variable, double value);

    void Unbind(string variable);
  }

  public class Context : IContext
  {
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

    private Dictionary<string, double> _context;

    internal Context()
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
          throw new UnboundVariableException();
      }
      set
      {
        _context[variable] = value;
      }
    }

    public bool IsBound(string variable)
    {
      return _context.ContainsKey(variable);
    }

    public void Bind(string variable, double value)
    {
      _context[variable] = value;
    }

    public void Unbind(string variable)
    {
      _context.Remove(variable);
    }
  }
}