namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal interface IValuable
    {
      string Symbol { get; }

      double Evaluate(IReadOnlyContext context);
    }

    internal abstract class Valuable : IValuable
    {
      public abstract string Symbol { get; }

      public abstract double Evaluate(IReadOnlyContext context);
    }
  }
}