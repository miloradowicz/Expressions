using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ExpressionEvaluatorLibrary.Operators;

namespace ExpressionEvaluatorLibrary
{
  internal static partial class Helpers
  {
    internal static OperatorInfo GetUnary(string symbol)
    {
      var fields = typeof(OperatorInfo).GetFields().Where(
        field =>
          Attribute.IsDefined(field, typeof(TypeAttribute)) &&
          ((TypeAttribute)Attribute.GetCustomAttribute(field, typeof(TypeAttribute))).Type == OperatorType.Unary &&
          ((SymbolAttribute)Attribute.GetCustomAttribute(field, typeof(SymbolAttribute))).Symbol == symbol
        );
      return (OperatorInfo)fields.First().GetValue(null);
    }

    internal static OperatorInfo GetBinary(string symbol)
    {
      var fields = typeof(OperatorInfo).GetFields().Where(
        field =>
          Attribute.IsDefined(field, typeof(TypeAttribute)) &&
          ((TypeAttribute)Attribute.GetCustomAttribute(field, typeof(TypeAttribute))).Type == OperatorType.Binary &&
          ((SymbolAttribute)Attribute.GetCustomAttribute(field, typeof(SymbolAttribute))).Symbol == symbol
        );
      return (OperatorInfo)fields.First().GetValue(null);
    }

    internal static OperatorInfo GetFunction(string symbol)
    {
      var fields = typeof(OperatorInfo).GetFields().Where(
        field =>
          Attribute.IsDefined(field, typeof(TypeAttribute)) &&
          ((TypeAttribute)Attribute.GetCustomAttribute(field, typeof(TypeAttribute))).Type == OperatorType.Function &&
          ((SymbolAttribute)Attribute.GetCustomAttribute(field, typeof(SymbolAttribute))).Symbol == symbol
        );
      return (OperatorInfo)fields.First().GetValue(null);
    }

    internal static OperatorInfo GetOther(string symbol)
    {
      var fields = typeof(OperatorInfo).GetFields().Where(
        field =>
          Attribute.IsDefined(field, typeof(TypeAttribute)) &&
          ((TypeAttribute)Attribute.GetCustomAttribute(field, typeof(TypeAttribute))).Type == OperatorType.Special &&
          ((SymbolAttribute)Attribute.GetCustomAttribute(field, typeof(SymbolAttribute))).Symbol == symbol
        );
      return (OperatorInfo)fields.First().GetValue(null);
    }

    internal static OperatorType GetOperatorType(this OperatorInfo operatorInfo)
    {
      var f = typeof(OperatorInfo).GetField(operatorInfo.ToString());
      return ((TypeAttribute)Attribute.GetCustomAttribute(f, typeof(TypeAttribute))).Type;
    }

    internal static PriorityGroup GetPriority(this OperatorInfo operatorInfo)
    {
      var f = typeof(OperatorInfo).GetField(operatorInfo.ToString());
      return ((PriorityAttribute)Attribute.GetCustomAttribute(f, typeof(PriorityAttribute))).Priority;
    }

    internal static Associativity GetAssociativity(this OperatorInfo operatorInfo)
    {
      var f = typeof(OperatorInfo).GetField(operatorInfo.ToString());
      return ((AssociativityAttribute)Attribute.GetCustomAttribute(f, typeof(AssociativityAttribute))).Associativity;
    }

    internal static int GetArity(this OperatorInfo operatorInfo)
    {
      var f = typeof(OperatorInfo).GetField(operatorInfo.ToString());
      return ((ArityAttribute)Attribute.GetCustomAttribute(f, typeof(ArityAttribute))).Arity;
    }
  }
}