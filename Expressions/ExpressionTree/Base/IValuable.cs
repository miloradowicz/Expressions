namespace Expressions.ExpressionTree
{
  internal interface IValuable
  {
    string Symbol { get; }

    double Evaluate(IReadOnlyContext context);
  }
}