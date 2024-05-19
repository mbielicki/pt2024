using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    class CatalogueViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IBook> _catalogue;
        private IBook? _currentBook;
        private IModelLayer _modelLayer;

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


        public CatalogueViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
                navigationStore, () => new CustomersViewModel(navigationStore, modelLayer));
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
                navigationStore, () => new SuppliersViewModel(navigationStore, modelLayer));
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
                navigationStore, () => new InvoicesViewModel(navigationStore, modelLayer));

            _modelLayer = modelLayer;
            _catalogue = _modelLayer.getBooksObservable();
        }
    }
}
