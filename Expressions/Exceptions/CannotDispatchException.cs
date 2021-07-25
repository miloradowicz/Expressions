using System;

namespace Expressions
{
  public class CannotDispatchException : BadSyntaxException
  {
    public CannotDispatchException()
    {
    }

    public CannotDispatchException(string message) : base(message)
    {
    }

    public CannotDispatchException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}