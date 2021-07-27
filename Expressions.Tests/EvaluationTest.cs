using System;
using System.Net.Http;
using System.Web;
using Xunit;
using Xunit.Abstractions;

namespace Expressions.Tests
{
  public class EvaluationTest
  {
    private const double error = 0.000000000000001;
    private static readonly HttpClient _httpClient = new HttpClient();
    private readonly ITestOutputHelper _output;

    public EvaluationTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [InlineData("((37 - 30) + (26 * (1 / 95)))")]
    [InlineData("5 - 2 + 4 * (8 - (5 + 1)) + 9")]
    [InlineData("(8 - 1 + 3) * 6 - ((3 + 7) * 2)")]
    [InlineData("(121+(101+0))")]
    [InlineData("(3*(5+2)*(10-7))")]
    public void Arithmetic_Test(string expression)
    {
      ExpressionBuilder expr = new ExpressionBuilder(expression);
      Context context = new Context();
      double computed = expr.Evaluate(context);
      double expected = GetResults(expression);
      _output.WriteLine($"Computed: {computed}");
      _output.WriteLine($"Expected: {expected}");
      Assert.True(Math.Abs(computed - expected) < error);
    }

    private double GetResults(string expression)
    {
      expression = HttpUtility.UrlEncode(expression);
      string request = $"http://api.mathjs.org/v4/?expr={expression}";
      var result = _httpClient.GetStringAsync(request);
      return Convert.ToDouble(result.Result);
    }
  }
}