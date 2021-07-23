using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUI.ViewModels
{
  internal class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string caller = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
  }
}