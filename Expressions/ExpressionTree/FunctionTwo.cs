using System.Collections.Generic;

namespace Expressions.ExpressionTree
{
  internal sealed class FunctionTwo : BinaryOperation
  {
    private static readonly Dictionary<string, BinaryDelegate> Functions = new Dictionary<string, BinaryDelegate>
    {
    };

    public FunctionTwo(string name, IValuable argument1, IValuable argument2) : base(name, argument1, argument2)
    {
    }

    protected override BinaryDelegate GetAction()
    {
      return Functions[_name];
    }
  }
}