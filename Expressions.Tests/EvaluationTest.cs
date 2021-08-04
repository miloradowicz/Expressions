using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using Xunit.Abstractions;

namespace Expressions.Tests
{
  public class EvaluationTest
  {
    private const double error = 1E-10;
    private const int precision = 50;
    private static readonly HttpClient _httpClient = new HttpClient();
    private readonly ITestOutputHelper _output;

    public EvaluationTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [InlineData("((37 - 30) + (26 * (1 / 95)))",
                "5 - 2 + 4 * (8 - (5 + 1)) + 9",
                "(8 - 1 + 3) * 6 - ((3 + 7) * 2)",
                "(121+(101+0))",
                "(3*(5+2)*(10-7))",
                "1-pi*sin(pi/0.355354)",
                "pow(24 * (54.231 + 523 % 654.234) - 234 * sqrt(5212.34) ^ log(412, 5345), 2)",
                "8 / 0")]
    public void All_Arithmetic_Tests_In_Parallel(params string[] expressions)
    {
      double[] computed = new double[expressions.Length];
      double[] expected = new double[expressions.Length];
      Context context = new Context();
      Parallel.For(0, expressions.Length,
        (i) =>
        {
          var request = GetResults(expressions[i]);
          var exprBuilder = new Expression(expressions[i]);
          computed[i] = exprBuilder.Evaluate(context);
          expected[i] = request.Result;
        });

      _output.WriteLine("".PadLeft(30, '='));
      _output.WriteLine($"Number of tests run: {expressions.Length}");
      _output.WriteLine("".PadLeft(30, '='));

      List<Xunit.Sdk.TrueException> fails = new List<Xunit.Sdk.TrueException>();

      for (int i = 0; i < expressions.Length; i++)
      {
        try
        {
          double difference = Math.Abs(computed[i] - expected[i]);
          double relError = Math.Abs(1d - computed[i] / expected[i]);
          _output.WriteLine($"Expression     : {expressions[i]}");
          _output.WriteLine($"Expected       : {expected[i]}");
          _output.WriteLine($"Computed       : {computed[i]}");
          _output.WriteLine($"Difference     : {difference}");
          _output.WriteLine($"Relative error : {relError}");
          _output.WriteLine("".PadLeft(30, '-'));
          Assert.True(computed[i] == expected[i] || relError < error);
        }
        catch (Xunit.Sdk.TrueException e)
        {
          fails.Add(e);
        }
      }

      Assert.True(fails.Count == 0);
    }

    [Theory]
    [InlineData("(xu + 43) ^ 5 / zsd * sin(d - 324)", "xu", "zsd", "d")]
    [InlineData("a * x ^ 3 + b * x ^ 2 + c * x + d", "a", "b", "c", "d", "x")]
    public void Arithmetic_Test_With_Variables(string expression, params string[] variables)
    {
      const int testRuns = 100;
      double[] computed = new double[testRuns];
      double[] expected = new double[testRuns];
      Dictionary<string, double>[] varsets = new Dictionary<string, double>[testRuns];
      Context[] contexts = new Context[testRuns];
      string[] substits = new string[testRuns];
      Random rnd = new Random();

      Parallel.For(0, testRuns,
        (i) =>
        {
          substits[i] = expression;
          varsets[i] = new Dictionary<string, double>();
          contexts[i] = new Context();
          foreach (var v in variables)
          {
            double d;
            lock (rnd)
              d = rnd.NextDouble() / rnd.NextDouble() * 1000;

            varsets[i].Add(v, d);
            contexts[i][v] = d;

            substits[i] = substits[i].Replace(v, d.ToString("e55"));
          }
          var request = GetResults(substits[i]);
          var exprBuilder = new Expression(expression);
          computed[i] = exprBuilder.Evaluate(contexts[i]);
          expected[i] = request.Result;
        });

      _output.WriteLine("".PadLeft(30, '='));
      _output.WriteLine($"Number of tests run: {testRuns}");
      _output.WriteLine("".PadLeft(30, '='));
      _output.WriteLine($"Expression : {expression}");
      _output.WriteLine("".PadLeft(30, '='));

      List<Xunit.Sdk.TrueException> fails = new List<Xunit.Sdk.TrueException>();

      for (int i = 0; i < testRuns; i++)
      {
        try
        {
          double difference = Math.Abs(computed[i] - expected[i]);
          double relError = Math.Abs(1d - computed[i] / expected[i]);
          _output.WriteLine($"Testrun        : {i + 1}");
          _output.WriteLine($"Variables      :");
          foreach (var v in variables)
            _output.WriteLine($"  {v,-12} : {varsets[i][v]}");
          _output.WriteLine($"Request        : {substits[i]}");
          _output.WriteLine($"Expected       : {expected[i]}");
          _output.WriteLine($"Computed       : {computed[i]}");
          _output.WriteLine($"Difference     : {difference}");
          _output.WriteLine($"Relative error : {relError}");
          _output.WriteLine("".PadLeft(30, '-'));
          Assert.True(computed[i] == expected[i] || relError < error);
        }
        catch (Xunit.Sdk.TrueException e)
        {
          fails.Add(e);
        }
      }

      Assert.True(fails.Count == 0);
    }

    private static async Task<double> GetResults(string expression)
    {
      expression = HttpUtility.UrlEncode(expression);
      string request = $"http://api.mathjs.org/v4/?expr={expression}&precision={precision}";
      string result = await _httpClient.GetStringAsync(request);
      return Convert.ToDouble(result != "Infinity" ? result : double.PositiveInfinity);
    }
  }
}