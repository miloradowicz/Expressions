using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluatorLibrary
{
  namespace ExpressionTree
  {
    internal sealed class FunctionOne : UnaryOperation
    {
      private static readonly Dictionary<string, UnaryDelegate> Functions = new Dictionary<string, UnaryDelegate>()
    {
      { "sin", Math.Sin },
      { "cos", Math.Cos },
      { "tan", Math.Tan },
      { "asin", Math.Asin },
      { "acos", Math.Acos },
      { "atan", Math.Atan },
      { "exp", Math.Exp },
      { "log", Math.Log },
    };

      protected override UnaryDelegate GetAction()
      {
        return Functions[_name];
      }

      public FunctionOne(string name, Valuable argument) : base(name, argument)
      {
      }
    }
  }
}