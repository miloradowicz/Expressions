using System;

namespace Expressions
{
  public class BadValueException : BadInputException
  {
    public BadValueException()
    {
    }

    public BadValueException(string message) : base(message)
    {
    }

    public BadValueException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}