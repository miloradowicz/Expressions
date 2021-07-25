using System;

namespace Expressions
{
  public class InvalidConstraintException : SolveException
  {
    public InvalidConstraintException()
    {
    }

    public InvalidConstraintException(string message) : base(message)
    {
    }

    public InvalidConstraintException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}