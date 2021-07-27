using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions.ExpressionTree
{
  internal class FunctionTwo : Function<Func<double, double, double>>
  {
    public FunctionTwo(string name, Func<double, double, double> function, params IValuable[] arguments) : base(name, function, arguments)
    {
    }

    public override double Evaluate(IReadOnlyContext context) => _function(_arguments[0].Evaluate(context), _arguments[1].Evaluate(context));
  }
}