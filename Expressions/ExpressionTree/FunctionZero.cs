using System;

namespace Expressions.ExpressionTree
{
  internal class FunctionZero : Function<Func<double>>
  {
    public FunctionZero(string name, Func<double> function, params IValuable[] arguments) : base(name, function, arguments)
    {
    }

    public override double Evaluate(IReadOnlyContext context) => _function();
  }
}