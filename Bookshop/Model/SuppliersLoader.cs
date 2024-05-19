using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Suppliers;
using System.Collections.ObjectModel;

namespace Bookshop.Model
{
    public class SuppliersLoader
    {
        public static ObservableCollection<ISupplier> loadSuppliers()
        {
            ObservableCollection<ISupplier>  suppliers = new ObservableCollection<ISupplier>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            SuppliersService service = new SuppliersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                suppliers.Add(service.get(id));
            }
            return suppliers;
        }
    }
}
