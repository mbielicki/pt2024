using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;
using Bookshop.Logic.Suppliers;

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
        public Counter<ID> supply(Book book, ID supplier, double price)
        {
            Counter<Book> books = new Counter<Book>();
            books.add(book);
            return supply(books, supplier, price);
        }
        public Counter<ID> supply(Counter<Book> books, ID supplier, double price)
        {
            SuppliersService suppliers = new SuppliersService(_storage);
            suppliers.get(supplier);

            CatalogueService catalogue = new CatalogueService(_storage);
            BookValidator validator = new BookValidator(_storage);

            Counter<ID> assignedIds = new Counter<ID>();

            foreach (var bookToNumber in books)
            {
                Book book = bookToNumber.Key;
                int number = bookToNumber.Value;
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

                _storage.Inventory.add(id, number);

                assignedIds.add(id);
            }

            SupplyRegisterEntry registerEntry = new SupplyRegisterEntry(
                null, assignedIds, supplier, price, DateTime.Now);

            return assignedIds;
            
        }

    }
}
