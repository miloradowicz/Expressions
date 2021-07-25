using System;

namespace Expressions
{
  public class UnsupportedOperationException : BadInputException
  {
    public UnsupportedOperationException()
    {
    }

    public UnsupportedOperationException(string message) : base(message)
    {
    }

    public UnsupportedOperationException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}