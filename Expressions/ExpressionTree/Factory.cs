using Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expressions.ExpressionTree
{
  using DelegateOne = Func<double, double>;
  using DelegateTwo = Func<double, double, double>;
  using DelegateZero = Func<double>;

  internal static class Factory
  {
    public static StringBuilder GetListing(IValuable root) => TopDown(root);

    public static Constant MakeConstant(double value) => new Constant(value);

    public static IValuable MakeFunction(OperatorInfo function, params IValuable[] arguments)
    {
      if (function.Arity != arguments.Length)
        throw new ArgumentException("The specified function doesn't take the given number of arguments.");

      switch (function.Arity)
      {
        case 0:
          return new FunctionZero(function.Symbol, (DelegateZero)function.Delegate, arguments);

        case 1:
          if (function == OperatorInfo.UnaryPlusOperator)
            return arguments[0];

          return new FunctionOne(function.Symbol, (DelegateOne)function.Delegate, arguments);

        case 2:
          return new FunctionTwo(function.Symbol, (DelegateTwo)function.Delegate, arguments);

        default:
          return new Function<Delegate>(function.Symbol, function.Delegate, arguments);
      }
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