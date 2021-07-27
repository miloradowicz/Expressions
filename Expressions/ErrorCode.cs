﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
  public enum ErrorCode
  {
    E_INPUT_EMPTYEXPRESSION,
    E_INPUT_UNRECOGNIZEDSYMBOL,
    E_INPUT_UNSUPPORTEDFUNCTION,
    E_INPUT_UNSUPPORTEDOPERATION,
    E_INTERNAL_COULDNOTDISPATCH,
    E_RUNTIME_UNBOUNDVARIABLE,
    E_RUNTIME_UNINITIALIZED,
    E_SOLVE_COULDNOTSOLVE,
    E_SOLVE_INVALIDCONSTRAINTS,
    E_SOLVE_INVALIDVARIABLE,
    E_SYNTAX_MISSINGARGUMENT,
    E_SYNTAX_MISMATCHEDPARENTHESES,
    E_SYNTAX_OPERANDEXPECTED,
    E_SYNTAX_OPERATOREXPECTED,
    E_SYNTAX_TOOMANYARGUMENTS,
  }
}