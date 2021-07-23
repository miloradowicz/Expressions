using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WPFUI.ViewModels
{
  internal abstract class CollectionViewModelBase<T> : ViewModelBase, INotifyCollectionChanged
  {
    public event NotifyCollectionChangedEventHandler CollectionChanged;

    protected virtual void OnCollectionChanged()
    {
      CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
  }
}