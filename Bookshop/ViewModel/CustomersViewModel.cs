using Bookshop.Commands;
using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;
using Bookshop.Model;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class CustomersViewModel : ViewModelBase
    {
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

        public CustomersViewModel(NavigationStore navigationStore)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                navigationStore, () => new CatalogueViewModel(navigationStore));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                navigationStore, () => new InvoicesViewModel(navigationStore));

            _customers = CustomersLoader.loadCustomers();
        }
    }
}
