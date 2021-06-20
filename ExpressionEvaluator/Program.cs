using System;
using System.Collections.Generic;
using System.IO;

using ExpressionEvaluatorLibrary;

namespace ExpressionEvaluator
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string expr = Console.ReadLine();

      ExpressionBuilder exprBuilder = new ExpressionBuilder(expr);
      Context context = exprBuilder.CreateContext();
      IReadOnlyCollection<string> vars = exprBuilder.GetVariables();
      double d = 0;
      foreach (string s in vars)
      {
        context.Bind(s, d);
        d += 1.5;
      }
      Console.WriteLine("Result is:");
      Console.WriteLine(exprBuilder.Evaluate(context));

      using (StreamWriter sw = new StreamWriter("output.dot"))
      {
        sw.Write(exprBuilder.GetListing());
      }

      Console.ReadKey(true);
    }
  }
}