using System;

namespace Expressions
{
  public class OperandExpectedExcpetion : BadSyntaxException
  {
    public OperandExpectedExcpetion()
    {
    }

    public OperandExpectedExcpetion(string message) : base(message)
    {
    }

    public OperandExpectedExcpetion(string message, Exception inner) : base(message, inner)
    {
    }
  }
}