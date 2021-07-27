using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Expressions.Tests
{
  public class TreeTest
  {
    private static int counter = 0;
    private readonly ITestOutputHelper _output;

    public TreeTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [InlineData("((37 - 30) + (26 * (1 / 95)))")]
    [InlineData("5 - 2 + 4 * (8 - (5 + 1)) + 9")]
    [InlineData("(8 - 1 + 3) * 6 - ((3 + 7) * 2)")]
    [InlineData("x * ((x - x) - x) + (x + x) / cos(x - x)")]
    [InlineData("exp(x * x)")]
    [InlineData("exp(sin(x + x)) / sin(x * exp(x * x)) + x * x")]
    [InlineData("exp(x / (x / x)) / exp(sin(x))")]
    public void Build_Trees(string expression)
    {
      ExpressionBuilder expr = new ExpressionBuilder(expression);
      string listing = expr.GetListing();
      _output.WriteLine(listing);

      using (StreamWriter sw = new StreamWriter($"testrun{counter++}.txt"))
      {
        sw.WriteLine(listing);
      }

      Assert.True(false);
    }
  }
}