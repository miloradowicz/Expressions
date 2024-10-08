﻿using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal class UnaryOperation : IValuable
    {
      internal delegate double UnaryDelegate(double operand);

      private static readonly Dictionary<string, UnaryDelegate> Operations = new Dictionary<string, UnaryDelegate>()
    {
      { "+", (double op) => op },
      { "-", (double op) => -op },
    };

      protected readonly string _name;
      protected readonly UnaryDelegate _action;
      protected readonly IValuable _operand;

      protected virtual UnaryDelegate GetAction()
      {
        return Operations[_name];
      }

      public UnaryOperation(string name, IValuable operand)
      {
        _name = name;
        _action = GetAction();
        _operand = operand;
      }

      public string Symbol
      {
        get { return _name; }
      }

      public double Evaluate(IReadOnlyContext context)
      {
        return _action(_operand.Evaluate(context));
      }
    }
  }
}