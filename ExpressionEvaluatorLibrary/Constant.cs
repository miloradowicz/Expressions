using System;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal sealed class Constant : Valuable
    {
      private readonly double _value;

      public Constant(double value)
      {
        _value = value;
      }

      public override string Symbol
      {
        get
        {
          return Convert.ToString(_value);
        }
      }

      public override double Evaluate(IReadOnlyContext context)
      {
        return _value;
      }
    }
  }
}