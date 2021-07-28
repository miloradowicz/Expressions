using System;

namespace Expressions.ExpressionTree
{
  internal class FunctionOne : Function<Func<double, double>>
  {
    public FunctionOne(string name, Func<double, double> function, params IValuable[] arguments) : base(name, function, arguments)
    {
    }

    public override double Evaluate(IReadOnlyContext context) => _function(_arguments[0].Evaluate(context));
  }
}