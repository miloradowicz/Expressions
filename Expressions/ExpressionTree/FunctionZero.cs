using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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