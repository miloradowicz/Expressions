using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Expressions.ExpressionTree
{
  internal class Function<T> : IFunction
    where T : Delegate
  {
    protected readonly IValuable[] _arguments;
    protected readonly T _function;
    protected readonly string _name;
    private int _arity;

    public Function(string name, T function, params IValuable[] arguments)
    {
      _name = name;
      _function = function;
      _arity = function.GetType().GenericTypeArguments.Length - 1;
      _arguments = arguments;

      if (_arity != _arguments.Length)
        throw new ArgumentException("The number of arguments passed does not match the number of arguments the function takes.");
    }

    public ReadOnlyCollection<IValuable> Arguments
    {
      get => Array.AsReadOnly(_arguments);
    }

    public string Symbol
    {
      get => _name;
    }

    public virtual double Evaluate(IReadOnlyContext context)
    {
      try
      {
        double[] args = new double[Arguments.Count];

        for (int i = 0; i < Arguments.Count; i++)
          args[i] = Arguments[i].Evaluate(context);

        return (double)_function.DynamicInvoke(args);
      }
      catch (ArgumentException)
      {
        throw new InvalidOperationException("The function does not accept arguments of type double.");
      }
      catch (InvalidCastException)
      {
        throw new InvalidOperationException("The function does not return a value of type double.");
      }
    }
  }
}