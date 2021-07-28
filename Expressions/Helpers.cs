using Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Expressions
{
  internal static partial class Helpers
  {
    private static Dictionary<OperatorInfo, (string, OperatorType, Priority, Associativity, int)> operators =
      new Dictionary<OperatorInfo, (string, OperatorType, Priority, Associativity, int)>();

    private static Dictionary<string, List<OperatorInfo>> symbols = new Dictionary<string, List<OperatorInfo>>();

    static Helpers()
    {
      var fields = typeof(OperatorInfo).GetFields(BindingFlags.Static | BindingFlags.Public);

      foreach (var f in fields)
      {
        var op = GetOperatorInfo(f);
        var symbol = GetSymbol(f);
        var type = GetOperatorType(f);
        var priority = GetPriority(f);
        var associativity = GetAssociativity(f);
        var arity = GetArity(f);

        operators.Add(op, (symbol, type, priority, associativity, arity));
        if (symbols.ContainsKey(symbol))
          symbols[symbol].Add(op);
        else
          symbols.Add(symbol, new List<OperatorInfo> { op });
      }
    }

    internal static OperatorInfo FindBinary(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.GetOperatorType() == OperatorType.Operator && op.GetArity() == 2);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    internal static OperatorInfo FindFunction(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.GetOperatorType() == OperatorType.Function);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    internal static OperatorInfo FindNamedConstant(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.GetOperatorType() == OperatorType.NamedConstant);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    internal static OperatorInfo FindSpecial(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.GetOperatorType() == OperatorType.Special);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    internal static OperatorInfo FindUnary(string symbol)
    {
      var oplist = symbols[symbol]
        .Where((op) => op.GetOperatorType() == OperatorType.Operator && op.GetArity() == 1);

      if (oplist.Count() != 1)
        throw new InvalidOperationException("Could not resolve the request.");

      return oplist.First();
    }

    internal static int GetArity(this OperatorInfo operatorInfo) => operators[operatorInfo].Item5;

    internal static Associativity GetAssociativity(this OperatorInfo operatorInfo) => operators[operatorInfo].Item4;

    internal static OperatorType GetOperatorType(this OperatorInfo operatorInfo) => operators[operatorInfo].Item2;

    internal static Priority GetPriority(this OperatorInfo operatorInfo) => operators[operatorInfo].Item3;

    internal static string GetSymbol(this OperatorInfo operatorInfo) => operators[operatorInfo].Item1;

    private static int GetArity(FieldInfo f)
    {
      return
        ((ArityAttribute)Attribute.GetCustomAttribute(f, typeof(ArityAttribute)))?.Arity
        ?? throw new ArgumentException("The given operator does not have arity specified.");
    }

    private static Associativity GetAssociativity(FieldInfo f)
    {
      return
        ((AssociativityAttribute)Attribute.GetCustomAttribute(f, typeof(AssociativityAttribute)))?.Associativity
        ?? throw new ArgumentException("The given operator does not have associativity specified.");
    }

    private static OperatorInfo GetOperatorInfo(FieldInfo f)
    {
      return
        (OperatorInfo)f.GetValue(null);
    }

    private static OperatorType GetOperatorType(FieldInfo f)
    {
      return
        ((OperatorTypeAttribute)Attribute.GetCustomAttribute(f, typeof(OperatorTypeAttribute)))?.OperatorType
        ?? throw new ArgumentException("The given operator does not have type specified.");
    }

    private static Priority GetPriority(FieldInfo f)
    {
      return
        ((PriorityAttribute)Attribute.GetCustomAttribute(f, typeof(PriorityAttribute)))?.Priority
        ?? throw new ArgumentException("The given operator does not have priority specified");
    }

    private static string GetSymbol(FieldInfo f)
    {
      return
        ((SymbolAttribute)Attribute.GetCustomAttribute(f, typeof(SymbolAttribute)))?.Symbol
        ?? throw new ArgumentException("The given operator does not have symbolic designation specified.");
    }
  }
}