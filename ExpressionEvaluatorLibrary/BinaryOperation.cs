using System;
using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal class BinaryOperation : Valuable
    {
      internal delegate double BinaryDelegate(double operand1, double operand2);

      private static readonly Dictionary<string, BinaryDelegate> Operations = new Dictionary<string, BinaryDelegate>()
    {
      { "+", (double op1, double op2) => op1 + op2 },
      { "-", (double op1, double op2) => op1 - op2 },
      { "*", (double op1, double op2) => op1 * op2 },
      { "/", (double op1, double op2) => op1 / op2 },
      { "^", (double op1, double op2) => Math.Pow(op1, op2) },
    };

      protected readonly string _name;
      protected readonly BinaryDelegate _action;
      protected readonly Valuable _operand1;
      protected readonly Valuable _operand2;

      protected virtual BinaryDelegate GetAction()
      {
        return Operations[_name];
      }

      public BinaryOperation(string name, Valuable operand1, Valuable operand2)
      {
        _name = name;
        _action = GetAction();
        _operand1 = operand1;
        _operand2 = operand2;
      }

      public override string Symbol
      {
        get { return _name; }
      }

      public override double Evaluate(IReadOnlyContext context)
      {
        return _action(_operand1.Evaluate(context), _operand2.Evaluate(context));
      }
    }
  }
}