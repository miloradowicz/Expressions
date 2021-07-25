using System.Collections.Generic;

namespace Expressions.ExpressionTree
{
  internal class Factory
  {
    private int _counter;
    private string _listing;
    private Dictionary<IValuable, int> _nodes;
    private HashSet<string> _variables;

    public Factory()
    {
      _listing = "\n";
      _counter = 0;
      _variables = new HashSet<string>();
      _nodes = new Dictionary<IValuable, int>();
    }

    public string GetListing()
    {
      return _listing;
    }

    public IReadOnlyCollection<string> GetVariables()
    {
      return _variables;
    }

    public FunctionOne MakeAcosFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("acos", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public BinaryOperation MakeAddition(IValuable operand1, IValuable operand2)
    {
      BinaryOperation binary = new BinaryOperation("+", operand1, operand2);
      _nodes[binary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{binary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand1]:0000} ;\n  n{_counter:0000} -- n{_nodes[operand2]:0000} ;\n";
      _counter++;
      return binary;
    }

    public FunctionOne MakeAsinFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("asin", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public FunctionOne MakeAtanFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("atan", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public Constant MakeConstant(double value)
    {
      Constant constant = new Constant(value);
      _nodes[constant] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label={constant.Symbol}] ;\n";
      _counter++;
      return constant;
    }

    public FunctionOne MakeCosFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("cos", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public BinaryOperation MakeDivision(IValuable operand1, IValuable operand2)
    {
      BinaryOperation binary = new BinaryOperation("/", operand1, operand2);
      _nodes[binary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{binary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand1]:0000} ;\n  n{_counter:0000} -- n{_nodes[operand2]:0000} ;\n";
      _counter++;
      return binary;
    }

    public FunctionOne MakeExpFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("exp", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public BinaryOperation MakeExponentiation(IValuable operand1, IValuable operand2)
    {
      BinaryOperation binary = new BinaryOperation("^", operand1, operand2);
      _nodes[binary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{binary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand1]:0000} ;\n  n{_counter:0000} -- n{_nodes[operand2]:0000} ;\n";
      _counter++;
      return binary;
    }

    public FunctionOne MakeLogFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("log", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public BinaryOperation MakeMultiplication(IValuable operand1, IValuable operand2)
    {
      BinaryOperation binary = new BinaryOperation("*", operand1, operand2);
      _nodes[binary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{binary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand1]:0000} ;\n  n{_counter:0000} -- n{_nodes[operand2]:0000} ;\n";
      _counter++;
      return binary;
    }

    public UnaryOperation MakeNegative(IValuable operand)
    {
      UnaryOperation unary = new UnaryOperation("-", operand);
      _nodes[unary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{unary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand]:0000} ;\n";
      _counter++;
      return unary;
    }

    public IValuable MakePositive(IValuable operand)
    {
      return operand;
    }

    public FunctionOne MakeSinFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("sin", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public BinaryOperation MakeSubtraction(IValuable operand1, IValuable operand2)
    {
      BinaryOperation binary = new BinaryOperation("-", operand1, operand2);
      _nodes[binary] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{binary.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[operand1]:0000} ;\n  n{_counter:0000} -- n{_nodes[operand2]:0000} ;\n";
      _counter++;
      return binary;
    }

    public FunctionOne MakeTanFunction(IValuable argument)
    {
      FunctionOne function = new FunctionOne("tan", argument);
      _nodes[function] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label=\"{function.Symbol}\"] ;\n  n{_counter:0000} -- n{_nodes[argument]:0000} ;\n";
      _counter++;
      return function;
    }

    public Variable MakeVariable(string name)
    {
      _variables.Add(name);
      Variable variable = new Variable(name);
      _nodes[variable] = _counter;
      _listing += $"  n{_counter:0000} ;\n  n{_counter:0000} [label={variable.Symbol}] ;\n";
      _counter++;
      return variable;
    }
  }
}