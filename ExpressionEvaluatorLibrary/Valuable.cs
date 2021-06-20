namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal interface IValuable
    {
      string Symbol { get; }

      double Evaluate(Context context);
    }

    internal abstract class Valuable : IValuable
    {
      public abstract string Symbol { get; }

      public abstract double Evaluate(Context context);
    }
  }
}