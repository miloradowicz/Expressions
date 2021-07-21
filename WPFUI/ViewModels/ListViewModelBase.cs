using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WPFUI.ViewModels
{
  internal abstract class ListViewModelBase<T> : ViewModelBase, IList<T>, INotifyCollectionChanged
  {
    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public abstract int Count { get; }
    public abstract bool IsReadOnly { get; }

    public abstract T this[int index] { get; set; }

    public abstract void Add(T item);

    public abstract void Clear();

    public abstract bool Contains(T item);

    public abstract void CopyTo(T[] array, int arrayIndex);

    public abstract IEnumerator<T> GetEnumerator();

    public abstract int IndexOf(T item);

    public abstract void Insert(int index, T item);

    public abstract bool Remove(T item);

    public abstract void RemoveAt(int index);

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    protected virtual void OnCollectionChanged()
    {
      CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
  }
}