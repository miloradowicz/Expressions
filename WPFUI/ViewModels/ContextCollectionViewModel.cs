using System.Collections.Generic;

namespace WPFUI.ViewModels
{
  using ContextViewModel = List<VariableViewModel>;

  internal class ContextListViewModel : ListViewModelBase<KeyValuePair<string, ContextViewModel>>
  {
    private Dictionary<string, ContextViewModel> _contexts = new Dictionary<string, ContextViewModel>();

    public ContextListViewModel()
    {
      NewContext = new RelayCommandWithParameter<string>(Add);
      DropContext = new RelayCommandWithParameter<string>(Remove);

      _contexts.Add("default", new ContextViewModel());
      _contexts["default"].Add(new VariableViewModel("lol", 1));
      _contexts["default"].Add(new VariableViewModel("cat", 2));
      _contexts.Add("another", new ContextViewModel());
      _contexts["another"].Add(new VariableViewModel("dog", 1.4));
      _contexts["another"].Add(new VariableViewModel("hen", 1.5));
      _contexts["another"].Add(new VariableViewModel("log", 2.5));
    }

    public RelayCommandWithParameter<string> DropContext { get; private set; }

    public RelayCommandWithParameter<string> NewContext { get; private set; }

    public override IEnumerator<KeyValuePair<string, ContextViewModel>> GetEnumerator()
    {
      return _contexts.GetEnumerator();
    }

    private void Add(string contextName)
    {
      if (_contexts.ContainsKey(contextName))
        return;

      _contexts.Add(contextName, new ContextViewModel());

      OnCollectionChanged();
    }

    private void Remove(string contextName)
    {
      if (!_contexts.ContainsKey(contextName))
        return;

      _contexts.Remove(contextName);

      OnCollectionChanged();
    }
  }
}