using System;

namespace Expressions
{
  public class MissingArgumentException : BadSyntaxException
  {
    public MissingArgumentException()
    {
    }

    public MissingArgumentException(string message) : base(message)
    {
    }

    public MissingArgumentException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}