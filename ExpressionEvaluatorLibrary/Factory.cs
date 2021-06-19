using System;
using System.Collections.Generic;

using ExpressionEvaluatorLibrary.ExpressionTree;

namespace ExpressionEvaluatorLibrary
{
  internal static class Factory
  {
    public static Constant MakeConstant(double value)
    {
      return new Constant(value);
    }

    public static Variable MakeVariable(string name)
    {
      return new Variable(name);
    }

    public static Valuable MakePositive(Valuable operand)
    {
      return operand;
    }

    public static UnaryOperation MakeNegative(Valuable operand)
    {
      return new UnaryOperation("-", operand);
    }

    public static BinaryOperation MakeAddition(Valuable operand1, Valuable operand2)
    {
      return new BinaryOperation("+", operand1, operand2);
    }

    public static BinaryOperation MakeSubtraction(Valuable operand1, Valuable operand2)
    {
      return new BinaryOperation("-", operand1, operand2);
    }

    public static BinaryOperation MakeMultiplication(Valuable operand1, Valuable operand2)
    {
      return new BinaryOperation("*", operand1, operand2);
    }

    public static BinaryOperation MakeDivision(Valuable operand1, Valuable operand2)
    {
      return new BinaryOperation("/", operand1, operand2);
    }

    public static BinaryOperation MakeExponentiation(Valuable operand1, Valuable operand2)
    {
      return new BinaryOperation("^", operand1, operand2);
    }

    public static FunctionOne MakeSinFunction(Valuable operand)
    {
      return new FunctionOne("sin", operand);
    }

    public static FunctionOne MakeCosFunction(Valuable operand)
    {
      return new FunctionOne("cos", operand);
    }

    public static FunctionOne MakeTanFunction(Valuable operand)
    {
      return new FunctionOne("tan", operand);
    }

    public static FunctionOne MakeAsinFunction(Valuable operand)
    {
      return new FunctionOne("asin", operand);
    }

    public static FunctionOne MakeAcosFunction(Valuable operand)
    {
      return new FunctionOne("acos", operand);
    }

    public static FunctionOne MakeAtanFunction(Valuable operand)
    {
      return new FunctionOne("atan", operand);
    }

    public static FunctionOne MakeExpFunction(Valuable operand)
    {
      return new FunctionOne("exp", operand);
    }

    public static FunctionOne MakeLogFunction(Valuable operand)
    {
      return new FunctionOne("log", operand);
    }
  }
}