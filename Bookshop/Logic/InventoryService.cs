using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;

namespace Bookshop.Logic
{
    public class InventoryService
    {
        IBookshopStorage _storage;
        public InventoryService(IBookshopStorage storage) { _storage = storage;  }
        public int count(ID book)
        {
            return _storage.Inventory.count(book);
        }
        public ID supply(Book book)
        {
            CatalogueService catalogue = new CatalogueService(_storage);
            BookValidator validator = new BookValidator(_storage);

            ID id;
            try
            {
                id = catalogue.add(book);
            }
            catch (ItemAlreadyExists)
            {
                id = _storage.Catalogue.get(b => validator.haveSameProperties(b, book)).Id;
                if (book.Id != null && book.Id != id)
                    throw new IdenticalItemWithDifferentIdExists();
            }
            _storage.Inventory.add(id);
            return id;
        }

    }
}
