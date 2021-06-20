using System.Collections.Generic;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal sealed class FunctionTwo : BinaryOperation
    {
      private static readonly Dictionary<string, BinaryDelegate> Functions = new Dictionary<string, BinaryDelegate>
      {
      };

      protected override BinaryDelegate GetAction()
      {
        return Functions[_name];
      }

      public FunctionTwo(string name, Valuable argument1, Valuable argument2) : base(name, argument1, argument2)
      {
      }
    }
  }
}