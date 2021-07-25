namespace Expressions.ExpressionTree
{
  internal sealed class Variable : IValuable
  {
    private readonly string _name;

    public Variable(string name)
    {
      _name = name;
    }

    public string Symbol
    {
      get { return _name; }
    }

    public double Evaluate(IReadOnlyContext context)
    {
      return context[_name];
    }
  }
}