using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ExpressionEvaluatorLibrary.Operators;

namespace ExpressionEvaluatorLibrary
{
  public static class MyExtensions
  {
    public static IReadOnlyCollection<T> AsReadOnly<T>(this ICollection<T> source)
    {
      if (source == null) throw new ArgumentNullException("source");
      return source as IReadOnlyCollection<T> ?? new ReadOnlyCollectionAdapter<T>(source);
    }

    private sealed class ReadOnlyCollectionAdapter<T> : IReadOnlyCollection<T>
    {
      private readonly ICollection<T> source;

      public ReadOnlyCollectionAdapter(ICollection<T> source) => this.source = source;

      public int Count => source.Count;

      public IEnumerator<T> GetEnumerator() => source.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
  }

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
          ((TypeAttribute)Attribute.GetCustomAttribute(field, typeof(TypeAttribute))).Type == OperatorType.Other &&
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