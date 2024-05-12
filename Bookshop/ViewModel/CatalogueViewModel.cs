using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Data.FileSystemStorage;
using System.Collections.ObjectModel;

namespace Bookshop.ViewModel
{
    class CatalogueViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IBook> _catalogue;

        public IEnumerable<IBook> Catalogue => _catalogue;

        public CatalogueViewModel()
        {
            _catalogue = new ObservableCollection<IBook>();

            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService service = new CatalogueService(storage);

            IEnumerable<ID> ids = service.getIds();
            foreach (ID id in ids)
            {
                _catalogue.Add(service.get(id));
            }
        }
    }
}
