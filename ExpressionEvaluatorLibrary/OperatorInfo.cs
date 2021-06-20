using System;

namespace ExpressionEvaluatorLibrary
{
  namespace Operators
  {
    internal enum PriorityGroup : int
    {
      Primary = 0,
      Unary = 1,
      Exponentiative = 2,
      Multiplicative = 3,
      Additive = 4,
    }

    internal enum Associativity : int
    {
      Left = 1,
      Right = -1,
      Undefined = 0,
    }

    internal enum OperatorType
    {
      Unary,
      Binary,
      Function,
      Other,
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class SymbolAttribute : Attribute
    {
      private string _symbol;

      public SymbolAttribute(string symbol)
      {
        _symbol = symbol;
      }

      public string Symbol
      {
        get { return _symbol; }
      }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class TypeAttribute : Attribute
    {
      private OperatorType _type;

      public TypeAttribute(OperatorType type)
      {
        _type = type;
      }

      public OperatorType Type
      {
        get { return _type; }
      }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class PriorityAttribute : Attribute
    {
      private PriorityGroup _priority;

      public PriorityAttribute(PriorityGroup priority)
      {
        _priority = priority;
      }

      public PriorityGroup Priority
      {
        get { return _priority; }
      }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class AssociativityAttribute : Attribute
    {
      private Associativity _associativity;

      public AssociativityAttribute(Associativity associativity)
      {
        _associativity = associativity;
      }

      public Associativity Associativity
      {
        get { return _associativity; }
      }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class ArityAttribute : Attribute
    {
      private int _arity;

      public ArityAttribute(int arity)
      {
        _arity = arity;
      }

      public int Arity
      {
        get { return _arity; }
      }
    }

    internal enum OperatorInfo
    {
      [Symbol("("), Type(OperatorType.Other), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(0)]
      LeftParenthesis,

      [Symbol(")"), Type(OperatorType.Other), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(0)]
      RightParenthesis,

      [Symbol("sin"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      SinFunction,

      [Symbol("cos"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      CosFunction,

      [Symbol("tan"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      TanFunction,

      [Symbol("asin"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      AsinFunction,

      [Symbol("acos"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      AcosFunction,

      [Symbol("atan"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      AtanFunction,

      [Symbol("exp"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      ExpFunction,

      [Symbol("log"), Type(OperatorType.Function), Priority(PriorityGroup.Primary), Associativity(Associativity.Left), Arity(1)]
      LogFunction,

      [Symbol("+"), Type(OperatorType.Unary), Priority(PriorityGroup.Unary), Associativity(Associativity.Left), Arity(1)]
      UnaryPlus,

      [Symbol("-"), Type(OperatorType.Unary), Priority(PriorityGroup.Unary), Associativity(Associativity.Left), Arity(1)]
      UnaryMinus,

      [Symbol("^"), Type(OperatorType.Binary), Priority(PriorityGroup.Exponentiative), Associativity(Associativity.Right), Arity(2)]
      Hat,

      [Symbol("*"), Type(OperatorType.Binary), Priority(PriorityGroup.Multiplicative), Associativity(Associativity.Left), Arity(2)]
      Star,

      [Symbol("/"), Type(OperatorType.Binary), Priority(PriorityGroup.Multiplicative), Associativity(Associativity.Left), Arity(2)]
      Slash,

      [Symbol("+"), Type(OperatorType.Binary), Priority(PriorityGroup.Additive), Associativity(Associativity.Left), Arity(2)]
      Plus,

      [Symbol("-"), Type(OperatorType.Binary), Priority(PriorityGroup.Additive), Associativity(Associativity.Left), Arity(2)]
      Minus,
    }
  }
}