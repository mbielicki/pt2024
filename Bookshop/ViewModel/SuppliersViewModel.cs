using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class SuppliersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupplier> _suppliers;
        private ISupplier? _currentSupplier;

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

        public SuppliersViewModel(NavigationStore navigationStore)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                navigationStore, () => new CatalogueViewModel(navigationStore));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                navigationStore, () => new CustomersViewModel(navigationStore));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                navigationStore, () => new InvoicesViewModel(navigationStore));

            _suppliers = SuppliersLoader.loadSuppliers();
        }
    }
}
