using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Presentation.Services;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
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

        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }

        public SupplyViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                new NavigationService<CatalogueViewModel>(
                    navigationStore, () => new CatalogueViewModel(navigationStore, modelLayer)
            ));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                new NavigationService<CustomersViewModel>(
                    navigationStore, () => new CustomersViewModel(navigationStore, modelLayer)
            ));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                new NavigationService<SuppliersViewModel>(
                    navigationStore, () => new SuppliersViewModel(navigationStore, modelLayer)
            ));

            _modelLayer = modelLayer;
            _supplies = _modelLayer.getSuppliesObservable();
        }
    }
}
