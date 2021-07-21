using System;
using System.Collections;
using System.Collections.Generic;

namespace WPFUI.ViewModels
{
  internal class ContextListViewModel : CollectionViewModelBase<ContextViewModel>, IEnumerable<ContextViewModel>
  {
    private List<ContextViewModel> _contexts = new List<ContextViewModel>();

    #region Constructors

    public ContextListViewModel()
    {
      NewContext = new RelayCommandWithParameter<ContextViewModel>(Add);
      DropContext = new RelayCommandWithParameter<ContextViewModel>((ContextViewModel cvm) => { Remove(cvm); });

      _contexts.Add(new ContextViewModel("default", new List<VariableViewModel>()));
      _contexts[0].Value.Add(new VariableViewModel("lol", 1));
      _contexts[0].Value.Add(new VariableViewModel("cat", 2));
      _contexts[0].Value.Add(new VariableViewModel("dog", 3));
      _contexts.Add(new ContextViewModel("another", new List<VariableViewModel>()));
      _contexts[1].Value.Add(new VariableViewModel("hog", 1));
      _contexts[1].Value.Add(new VariableViewModel("fog", 1));
      _contexts[1].Value.Add(new VariableViewModel("tic", 1));
      _contexts[1].Value.Add(new VariableViewModel("tac", 1));
    }

    #endregion Constructors

    #region Commands

    public RelayCommandWithParameter<ContextViewModel> DropContext { get; private set; }
    public RelayCommandWithParameter<ContextViewModel> NewContext { get; private set; }

    #endregion Commands

    public IEnumerator<ContextViewModel> GetEnumerator() => _contexts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Add(ContextViewModel item)
    {
      _contexts.Add(item);

      OnCollectionChanged();
    }

    private bool Remove(ContextViewModel item)
    {
      bool result = _contexts.Remove(item);

      OnCollectionChanged();

      return result;
    }
  }
}