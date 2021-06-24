namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal sealed class Variable : Valuable
    {
      private readonly string _name;

      public Variable(string name)
      {
        _name = name;
      }

      public override string Symbol
      {
        get { return _name; }
      }

      public override double Evaluate(IReadOnlyContext context)
      {
        return context[_name];
      }
    }
  }
}