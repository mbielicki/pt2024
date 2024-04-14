using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;
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
        public Counter<ID> supply(ID book, ID supplier, double price)
        {
            Counter<ID> books = new Counter<ID>();
            books.Add(book);
            return supply(books, supplier, price);
        }
        public Counter<ID> supply(Counter<ID> books, ID supplier, double price)
        {
            SuppliersService suppliers = new SuppliersService(_storage);
            suppliers.get(supplier);

            CatalogueService catalogue = new CatalogueService(_storage);

            Counter<ID> assignedIds = new Counter<ID>();

            foreach (var bookToNumber in books)
            {
                ID book = bookToNumber.Key;
                int number = bookToNumber.Value;

                catalogue.get(book);

                _storage.Inventory.add(book, number);

                assignedIds.Add(book);
            }

            SupplyRegisterEntry registerEntry = new SupplyRegisterEntry(
                null, assignedIds, supplier, price, DateTime.Now);

            _storage.SupplyRegister.add(registerEntry);

            return assignedIds;
            
        }

    }
}
