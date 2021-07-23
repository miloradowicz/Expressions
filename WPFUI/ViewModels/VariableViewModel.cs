using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
  public class VariableViewModel : ViewModelBase
  {
    private string _name;
    private double? _value;

    public VariableViewModel()
    {
      _name = String.Empty;
      _value = null;
    }

    public VariableViewModel(string name, double value)
    {
      _name = name;
      _value = value;
    }

    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        if (value == _name)
          return;

        _name = value;

        OnPropertyChanged();
      }
    }

    public double? Value
    {
      get
      {
        return _value;
      }
      set
      {
        if (value == _value)
          return;

        _value = value;

        OnPropertyChanged();
      }
    }
  }
}