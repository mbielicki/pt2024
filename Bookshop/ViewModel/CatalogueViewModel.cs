using Bookshop.Commands;
using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class CatalogueViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IBook> _catalogue;
        private IBook? _currentBook;

        public IEnumerable<IBook> Catalogue => _catalogue;

        public IBook? CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }

        public CatalogueViewModel(NavigationStore navigationStore)
        {
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                navigationStore, () => new CustomersViewModel(navigationStore));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                navigationStore, () => new InvoicesViewModel(navigationStore));

            _catalogue = new ObservableCollection<IBook>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            CatalogueService service = new CatalogueService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                _catalogue.Add(service.get(id));
            }
        }
    }
}
