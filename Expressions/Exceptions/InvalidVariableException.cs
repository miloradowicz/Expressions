using System;

namespace Expressions
{
  public class InvalidVariableException : SolveException
  {
    public InvalidVariableException()
    {
    }

    public InvalidVariableException(string message) : base(message)
    {
    }

    public InvalidVariableException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}