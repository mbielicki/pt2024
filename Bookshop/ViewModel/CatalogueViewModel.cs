using Bookshop.Model.Data.API;
using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic.Catalogue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
