using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class CustomersViewModel : ViewModelBase
    {
        private IModelLayer _modelLayer;
        private readonly ObservableCollection<ICustomer> _customers;
        private ICustomer? _currentCustomer;

        public IEnumerable<ICustomer> Customers => _customers;

        public ICustomer? CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }

        public CustomersViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                navigationStore, () => new CatalogueViewModel(navigationStore, modelLayer));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore, modelLayer));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                navigationStore, () => new InvoicesViewModel(navigationStore, modelLayer));

            _modelLayer = modelLayer;
            _customers = modelLayer.getCustomersObservable();
        }
    }
}
