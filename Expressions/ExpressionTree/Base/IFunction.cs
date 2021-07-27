using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions.ExpressionTree
{
  internal interface IFunction : IValuable
  {
    ReadOnlyCollection<IValuable> Arguments { get; }
  }
}