using System;

namespace Expressions
{
  public class TooManyArgumentsException : BadSyntaxException
  {
    public TooManyArgumentsException()
    {
    }

    public TooManyArgumentsException(string message) : base(message)
    {
    }

    public TooManyArgumentsException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}