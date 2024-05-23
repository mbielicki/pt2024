using Model.Model.Entities;
using Presentation.Model;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IInventoryEntry> _inventory;
        private IInventoryEntry? _currentInventoryItem;
        private IModelLayer _modelLayer;

        public IEnumerable<IInventoryEntry> InventoryItems => _inventory;

        public IInventoryEntry? CurrentInventoryItem
        {
            get => _currentInventoryItem;
            set
            {
                _currentInventoryItem = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public InventoryViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _inventory = _modelLayer.getInventoryObservable();
        }
    }
}
