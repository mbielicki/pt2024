using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Presentation.Services;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class SuppliersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupplier> _suppliers;
        private ISupplier? _currentSupplier;
        private IModelLayer _modelLayer;

        public IEnumerable<ISupplier> Suppliers => _suppliers;

        public ISupplier? CurrentSupplier
        {
            get => _currentSupplier;
            set
            {
                _currentSupplier = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }

        public SuppliersViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                new NavigationService<CatalogueViewModel>(
                    navigationStore, () => new CatalogueViewModel(navigationStore, modelLayer)
            ));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                new NavigationService<CustomersViewModel>(
                    navigationStore, () => new CustomersViewModel(navigationStore, modelLayer)
            ));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                new NavigationService<InvoicesViewModel>(
                    navigationStore, () => new InvoicesViewModel(navigationStore, modelLayer)
            ));

            _modelLayer = modelLayer;
            _suppliers = _modelLayer.getSuppliersObservable();
        }
    }
}
