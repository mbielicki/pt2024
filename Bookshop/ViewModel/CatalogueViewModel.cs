using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
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
