﻿using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  public interface IReadOnlyContext
  {
    double this[string variable] { get; }

    IReadOnlyCollection<string> GetBoundVariables();

    Context Clone();

    bool IsBound(string variable);
  }

  internal interface IContext : IReadOnlyContext
  {
    IReadOnlyContext AsReadOnly();

    new double this[string variable] { get; set; }

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

    public IReadOnlyContext AsReadOnly()
    {
      return new ReadOnlyContext(this);
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

    public void Bind(string variable, double value)
    {
      _context[variable] = value;
    }

    public void Unbind(string variable)
    {
      _context.Remove(variable);
    }
  }

  public class ReadOnlyContext : IReadOnlyContext
  {
    private Context _context;

    internal ReadOnlyContext(Context context)
    {
      _context = context;
    }

    public double this[string variable]
    {
      get
      {
        return _context[variable];
      }
    }

    public IReadOnlyCollection<string> GetBoundVariables()
    {
      return _context.GetBoundVariables();
    }

    public Context Clone()
    {
      return _context.Clone();
    }

    public bool IsBound(string variable)
    {
      return _context.IsBound(variable);
    }
  }
}