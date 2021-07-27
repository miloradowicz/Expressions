using System;

namespace Expressions.ExpressionTree
{
  internal sealed class Constant : IValuable
  {
    private readonly double _value;

    public Constant(double value) => _value = value;

    public string Symbol
    {
      get => Convert.ToString(_value);
    }

    public double Evaluate(IReadOnlyContext context) => _value;
  }
}