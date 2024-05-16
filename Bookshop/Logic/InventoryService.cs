using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Suppliers;

namespace Bookshop.Logic
{
    public class InventoryService
    {
        IBookshopStorage _storage;
        public InventoryService(IBookshopStorage storage) { _storage = storage; }
        public int count(int bookId)
        {
            return _storage.Inventory.count(bookId);
        }
        public void supply(int bookId, int supplierId, double price)
        {
            Counter<int> books = new Counter<int>();
            books.Add(bookId);
            supply(books, supplierId, price);
        }
        public void supply(Counter<int> bookIds, int supplierId, double price)
        {
            SuppliersService suppliers = new SuppliersService(_storage);
            ISupplier supplier = suppliers.get(supplierId);

            CatalogueService catalogue = new CatalogueService(_storage);

            Counter<IBook> books = new Counter<IBook>();

            foreach (var bookToNumber in bookIds)
            {
                int book = bookToNumber.Key;
                int number = bookToNumber.Value;

                books.Set(catalogue.get(book), number);

                _storage.Inventory.add(book, number);
            }


            SimpleSupplyRegisterEntry registerEntry = new SimpleSupplyRegisterEntry(
                null, books, supplier, price, DateTime.Now);

            _storage.SupplyRegister.add(registerEntry);
        }

    }
}
