using System;

namespace Expressions
{
  public class CouldNotSolveException : SolveException
  {
    public CouldNotSolveException()
    {
    }

    public CouldNotSolveException(string message) : base(message)
    {
    }

    public CouldNotSolveException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}