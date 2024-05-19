using Bookshop.Commands;
using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Suppliers;
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

        public SuppliersViewModel(NavigationStore navigationStore)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(navigationStore, () => new CatalogueViewModel(navigationStore));
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(navigationStore, () => new CustomersViewModel(navigationStore));

            _suppliers = new ObservableCollection<ISupplier>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            SuppliersService service = new SuppliersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                _suppliers.Add(service.get(id));
            }
        }
    }
}
