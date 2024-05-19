using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using System.Collections.ObjectModel;

namespace Bookshop.Model
{
    public class BooksLoader
    {
        public static ObservableCollection<IBook> loadBooks()
        {
            ObservableCollection<IBook> books = new ObservableCollection<IBook>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            CatalogueService service = new CatalogueService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                books.Add(service.get(id));
            }

            return books;
        }
    }
}
