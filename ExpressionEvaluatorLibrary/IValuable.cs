namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal interface IValuable
    {
      string Symbol { get; }

      double Evaluate(IReadOnlyContext context);
    }
  }
}