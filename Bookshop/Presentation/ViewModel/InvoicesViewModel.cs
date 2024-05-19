using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
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
        private IModelLayer _modelLayer;

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

        public InvoicesViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
                navigationStore, () => new CatalogueViewModel(navigationStore, modelLayer));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                navigationStore, () => new CustomersViewModel(navigationStore, modelLayer));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore, modelLayer));

            _modelLayer = modelLayer;
            _invoices = _modelLayer.getInvoicesObservable();
        }
    }
}
