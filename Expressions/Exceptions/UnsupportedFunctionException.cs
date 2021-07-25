using System;

namespace Expressions
{
  public class UnsupportedFunctionException : BadInputException
  {
    public UnsupportedFunctionException()
    {
    }

    public UnsupportedFunctionException(string message) : base(message)
    {
    }

    public UnsupportedFunctionException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}