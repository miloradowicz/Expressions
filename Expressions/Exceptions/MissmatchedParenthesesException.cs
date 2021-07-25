using System;

namespace Expressions
{
  public class MismatchedParenthesesException : BadSyntaxException
  {
    public MismatchedParenthesesException()
    {
    }

    public MismatchedParenthesesException(string message) : base(message)
    {
    }

    public MismatchedParenthesesException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}