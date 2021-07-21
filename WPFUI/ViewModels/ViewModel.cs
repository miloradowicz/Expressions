using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionEvaluatorLibrary;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WPFUI
{
  internal class ViewModel : INotifyPropertyChanged
  {
    private string _expression;
    private ExpressionBuilder _exprBilder;
    private IReadOnlyCollection<string> _variables;
    private bool _success;
    private double _result;
    private string _errorMessage;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Expression
    {
      get
      {
        return _expression;
      }
      set
      {
        if (value != _expression)
        {
          _expression = value;
          OnPropertyChanged();
        }
      }
    }

    public bool Success { get; private set; }
    public double Result { get; private set; }
    public string ErrorMessage { get; private set; }

    private void OnPropertyChanged([CallerMemberName] string caller = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }

    private void Parse()
    {
      try
      {
        _exprBilder = new ExpressionBuilder(_expression);
        _variables = _exprBilder.GetVariables();
      }
      catch (ExpressionBuilder.EmptyExpressionException)
      {
        ErrorMessage = "Empty input";
        Success = false;
      }
      catch (ExpressionBuilder.UnrecognizedSymbolException)
      {
        ErrorMessage = "Unrecognized character";
        Success = false;
      }
      catch (ExpressionBuilder.BadValueException)
      {
        ErrorMessage = "Unsupported value";
        Success = false;
      }
      catch (ExpressionBuilder.UnsupportedOperationException)
      {
        ErrorMessage = "Unsupported operation";
        Success = false;
      }
      catch (ExpressionBuilder.UnsupportedFunctionException)
      {
        ErrorMessage = "Unsupported function";
        Success = false;
      }
      catch (ExpressionBuilder.MismatchedParenthesesException)
      {
        ErrorMessage = "Mismatched parentheses";
        Success = false;
      }
      catch (ExpressionBuilder.BadSyntaxException)
      {
        ErrorMessage = "Bad syntax";
        Success = false;
      }
    }

    private void Evaluate()
    {
    }
  }
}