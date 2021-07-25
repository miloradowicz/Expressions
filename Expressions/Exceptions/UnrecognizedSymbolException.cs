using System;

namespace Expressions
{
  public class UnrecognizedSymbolException : BadInputException
  {
    public UnrecognizedSymbolException()
    {
    }

    public UnrecognizedSymbolException(string message) : base(message)
    {
    }

    public UnrecognizedSymbolException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}