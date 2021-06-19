using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal class UnaryOperation : Valuable
    {
      internal delegate double UnaryDelegate(double operand);

      private static readonly Dictionary<string, UnaryDelegate> Operations = new Dictionary<string, UnaryDelegate>()
    {
      { "+", (double op) => op },
      { "-", (double op) => -op },
    };

      protected readonly string _name;
      protected readonly UnaryDelegate _action;
      protected readonly Valuable _operand;

      protected virtual UnaryDelegate GetAction()
      {
        return Operations[_name];
      }

      public UnaryOperation(string name, Valuable operand)
      {
        _name = name;
        _action = GetAction();
        _operand = operand;
      }

      public override string Symbol
      {
        get { return _name; }
      }

      public override double Evaluate(Context context)
      {
        return _action(_operand.Evaluate(context));
      }
    }
  }
}