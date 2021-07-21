using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
  internal class ContextViewModel : ViewModelBase
  {
    private readonly string _key;
    private readonly List<VariableViewModel> _value;

    public ContextViewModel(string key, List<VariableViewModel> value)
    {
      _key = key;
      _value = value;
    }

    public string Key { get => _key; }
    public List<VariableViewModel> Value { get => _value; }
  }
}