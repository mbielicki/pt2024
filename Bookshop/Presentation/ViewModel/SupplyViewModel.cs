using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;
using System.Collections.ObjectModel;

namespace Bookshop.Presentation.ViewModel
{
    class SupplyViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupply> _supplies;
        private ISupply? _currentSupply;
        private IModelLayer _modelLayer;

        public IEnumerable<ISupply> Supplies => _supplies;

        public ISupply? CurrentSupply
        {
            get => _currentSupply;
            set
            {
                _currentSupply = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public SupplyViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _supplies = _modelLayer.getSuppliesObservable();
        }
    }
}
