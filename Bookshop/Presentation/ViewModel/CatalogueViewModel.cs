using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.ViewModel;
using Bookshop.Presentation.Stores;
using System.Collections.ObjectModel;

namespace Bookshop.Presentation.ViewModel
{
    public class CatalogueViewModel : ViewModelBase
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

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public CatalogueViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _catalogue = _modelLayer.getBooksObservable();
        }
    }
}
