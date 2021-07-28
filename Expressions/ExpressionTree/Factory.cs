using System;
using System.Collections.Generic;
using System.Text;
using Expressions.Operators;

namespace Expressions.ExpressionTree
{
  using DelegateZero = Func<double>;
  using DelegateOne = Func<double, double>;
  using DelegateTwo = Func<double, double, double>;

  internal static class Factory
  {
    private static Dictionary<OperatorInfo, Delegate> funcs = new Dictionary<OperatorInfo, Delegate>
    {
      { OperatorInfo.PiConstant, (DelegateZero)(() => Math.PI) },
      { OperatorInfo.SinFunction, (DelegateOne)((x) => Math.Sin(x)) },
      { OperatorInfo.CosFunction, (DelegateOne)((x) => Math.Cos(x)) },
      { OperatorInfo.TanFunction, (DelegateOne)((x) => Math.Tan(x)) },
      { OperatorInfo.AsinFunction, (DelegateOne)((x) => Math.Asin(x)) },
      { OperatorInfo.AcosFunction, (DelegateOne)((x) => Math.Acos(x)) },
      { OperatorInfo.AtanFunction, (DelegateOne)((x) => Math.Atan(x)) },
      { OperatorInfo.ExpFunction, (DelegateOne)((x) => Math.Exp(x)) },
      { OperatorInfo.LogFunction, (DelegateOne)((x) => Math.Log(x)) },
      { OperatorInfo.UnaryPlusOperator, (DelegateOne)((x) => x) },
      { OperatorInfo.UnaryMinusOperator, (DelegateOne)((x) => -x) },
      { OperatorInfo.HatOperator, (DelegateTwo)((x, y) => Math.Pow(x, y)) },
      { OperatorInfo.StarOperator, (DelegateTwo)((x, y) => x * y) },
      { OperatorInfo.SlashOperator, (DelegateTwo)((x, y) => x / y) },
      { OperatorInfo.PlusOperator, (DelegateTwo)((x, y) => x + y) },
      { OperatorInfo.MinusOperator, (DelegateTwo)((x, y) => x - y) }
    };

    public static StringBuilder GetListing(IValuable root) => TopDown(root);

    public static FunctionOne MakeAcosFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.AcosFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionTwo MakeAddition(IValuable operand1, IValuable operand2)
    {
      OperatorInfo f = OperatorInfo.PlusOperator;
      return new FunctionTwo(f.GetSymbol(), (DelegateTwo)funcs[f], operand1, operand2);
    }

    public static FunctionOne MakeAsinFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.AsinFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionOne MakeAtanFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.AtanFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static Constant MakeConstant(double value) => new Constant(value);

    public static FunctionOne MakeCosFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.CosFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionTwo MakeDivision(IValuable operand1, IValuable operand2)
    {
      OperatorInfo f = OperatorInfo.SlashOperator;
      return new FunctionTwo(f.GetSymbol(), (DelegateTwo)funcs[f], operand1, operand2);
    }

    public static FunctionOne MakeExpFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.ExpFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionTwo MakeExponentiation(IValuable operand1, IValuable operand2)
    {
      OperatorInfo f = OperatorInfo.HatOperator;
      return new FunctionTwo(f.GetSymbol(), (DelegateTwo)funcs[f], operand1, operand2);
    }

    public static FunctionOne MakeLogFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.LogFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionTwo MakeMultiplication(IValuable operand1, IValuable operand2)
    {
      OperatorInfo f = OperatorInfo.StarOperator;
      return new FunctionTwo(f.GetSymbol(), (DelegateTwo)funcs[f], operand1, operand2);
    }

    public static FunctionZero MakeNamedConstant(string name)
    {
      OperatorInfo f = Helpers.FindNamedConstant(name);
      return new FunctionZero(f.GetSymbol(), (DelegateZero)funcs[f]);
    }

    public static FunctionOne MakeNegative(IValuable operand)
    {
      OperatorInfo f = OperatorInfo.UnaryMinusOperator;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], operand);
    }

    public static IValuable MakePositive(IValuable operand) => operand;

    public static FunctionOne MakeSinFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.SinFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static FunctionTwo MakeSubtraction(IValuable operand1, IValuable operand2)
    {
      OperatorInfo f = OperatorInfo.MinusOperator;
      return new FunctionTwo(f.GetSymbol(), (DelegateTwo)funcs[f], operand1, operand2);
    }

    public static FunctionOne MakeTanFunction(IValuable argument)
    {
      OperatorInfo f = OperatorInfo.TanFunction;
      return new FunctionOne(f.GetSymbol(), (DelegateOne)funcs[f], argument);
    }

    public static Variable MakeVariable(string name) => new Variable(name);

    private static StringBuilder TopDown(IValuable root)
    {
      StringBuilder listing = new StringBuilder();

      if (root == null)
        return listing;

      int behind, ahead;
      behind = ahead = -1;
      Queue<IValuable> q = new Queue<IValuable>();

      q.Enqueue(root);
      ahead++;
      while (q.Count > 0)
      {
        IValuable node = q.Dequeue();
        behind++;
        if (node == null)
          throw new ArgumentNullException("The expression tree is invalid.");

        listing.Append($@"
  n{behind:0000} ;
  n{behind:0000} [label=""{node.Symbol}""] ;");

        if (node is IFunction f)
        {
          foreach (var a in f.Arguments)
          {
            q.Enqueue(a);
            ahead++;

            listing.Append($@"
  n{behind:0000} -> n{ahead:0000} ;");
          }
        }
      }

      return listing;
    }
  }
}