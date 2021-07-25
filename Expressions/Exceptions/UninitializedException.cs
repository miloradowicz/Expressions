using System;

namespace Expressions
{
  public class UninitializedException : RuntimeException
  {
    public UninitializedException()
    {
    }

    public UninitializedException(string message) : base(message)
    {
    }

    public UninitializedException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}