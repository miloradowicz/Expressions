using System;

namespace Expressions
{
  public abstract class BadSyntaxException : Exception
  {
    public BadSyntaxException()
    {
    }

    public BadSyntaxException(string message) : base(message)
    {
    }

    public BadSyntaxException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}