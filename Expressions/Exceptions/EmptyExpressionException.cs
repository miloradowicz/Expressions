using System;

namespace Expressions
{
  public class EmptyExpressionException : Exception
  {
    public EmptyExpressionException()
    {
    }

    public EmptyExpressionException(string message) : base(message)
    {
    }

    public EmptyExpressionException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}