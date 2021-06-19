using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  internal interface IContext
  {
    double this[string variable] { get; set; }

    void Bind(string variable, double value);

    void Unbind(string variable);
  }

  public class Context : IContext
  {
    private Dictionary<string, double> _context;

    internal Context()
    {
      _context = new Dictionary<string, double>();
    }

    public double this[string variable]
    {
      get { return _context[variable]; }
      set { _context[variable] = value; }
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