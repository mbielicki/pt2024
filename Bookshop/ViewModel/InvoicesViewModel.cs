using Bookshop.Commands;
using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using Bookshop.Model;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class InvoicesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IInvoice> _invoices;
        private IInvoice? _currentInvoice;

        public IEnumerable<IInvoice> Invoices => _invoices;

        public IInvoice? CurrentInvoice
        {
            get => _currentInvoice;
            set
            {
                _currentInvoice = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }

        public InvoicesViewModel(NavigationStore navigationStore)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                navigationStore, () => new CatalogueViewModel(navigationStore));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                navigationStore, () => new CustomersViewModel(navigationStore));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore));

            _invoices = InvoicesLoader.loadInvoices();
        }
    }
}
