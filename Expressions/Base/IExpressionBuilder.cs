using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
  internal interface IExpressionBuilder
  {
    double Evaluate(IReadOnlyContext context);

    double Solve(IReadOnlyContext context, string unknown, double guess, double error, int steps);
  }
}