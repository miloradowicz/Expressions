using System;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal sealed class Constant : IValuable
    {
      private readonly double _value;

      public Constant(double value)
      {
        _value = value;
      }

      public string Symbol
      {
        get
        {
          return Convert.ToString(_value);
        }
      }

      public double Evaluate(IReadOnlyContext context)
      {
        return _value;
      }
    }
  }
}