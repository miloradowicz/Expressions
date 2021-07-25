using System.Collections.Generic;

namespace Expressions.ExpressionTree
{
  internal class UnaryOperation : IValuable
  {
    protected readonly UnaryDelegate _action;

    protected readonly string _name;

    protected readonly IValuable _operand;

    private static readonly Dictionary<string, UnaryDelegate> Operations = new Dictionary<string, UnaryDelegate>()
    {
      { "+", (double op) => op },
      { "-", (double op) => -op },
    };

    public UnaryOperation(string name, IValuable operand)
    {
      _name = name;
      _action = GetAction();
      _operand = operand;
    }

    internal delegate double UnaryDelegate(double operand);

    public string Symbol
    {
      get { return _name; }
    }

    public double Evaluate(IReadOnlyContext context)
    {
      return _action(_operand.Evaluate(context));
    }

    protected virtual UnaryDelegate GetAction()
    {
      return Operations[_name];
    }
  }
}