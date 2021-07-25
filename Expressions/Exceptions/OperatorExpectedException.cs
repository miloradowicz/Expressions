using System;

namespace Expressions
{
  public class OperatorExpectedException : BadSyntaxException
  {
    public OperatorExpectedException()
    {
    }

    public OperatorExpectedException(string message) : base(message)
    {
    }

    public OperatorExpectedException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}