using System;

namespace Expressions
{
  public class UnboundVariableException : RuntimeException
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
}