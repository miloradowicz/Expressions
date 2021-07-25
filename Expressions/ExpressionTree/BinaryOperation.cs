using System;
using System.Collections.Generic;

namespace Expressions.ExpressionTree
{
  internal class BinaryOperation : IValuable
  {
    protected readonly BinaryDelegate _action;

    protected readonly string _name;

    protected readonly IValuable _operand1;

    protected readonly IValuable _operand2;

    private static readonly Dictionary<string, BinaryDelegate> Operations = new Dictionary<string, BinaryDelegate>()
    {
      { "+", (double op1, double op2) => op1 + op2 },
      { "-", (double op1, double op2) => op1 - op2 },
      { "*", (double op1, double op2) => op1 * op2 },
      { "/", (double op1, double op2) => op1 / op2 },
      { "^", (double op1, double op2) => Math.Pow(op1, op2) },
    };

    public BinaryOperation(string name, IValuable operand1, IValuable operand2)
    {
      _name = name;
      _action = GetAction();
      _operand1 = operand1;
      _operand2 = operand2;
    }

    internal delegate double BinaryDelegate(double operand1, double operand2);

    public string Symbol
    {
      get { return _name; }
    }

    public double Evaluate(IReadOnlyContext context)
    {
      return _action(_operand1.Evaluate(context), _operand2.Evaluate(context));
    }

    protected virtual BinaryDelegate GetAction()
    {
      return Operations[_name];
    }
  }
}