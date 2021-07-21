using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFUI.ViewModels
{
  internal class RelayCommandWithParameter<T> : ICommand
  {
    private Action<T> _action;

    public RelayCommandWithParameter(Action<T> action)
    {
      _action = action;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter) => _action((T)parameter);
  }
}