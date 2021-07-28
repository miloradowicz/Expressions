using System.Collections.ObjectModel;

namespace Expressions.ExpressionTree
{
  internal interface IFunction : IValuable
  {
    ReadOnlyCollection<IValuable> Arguments { get; }
  }
}