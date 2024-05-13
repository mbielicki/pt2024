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
        public int count(ID book)
        {
            return _storage.Inventory.count(book);
        }
        public void supply(ID book, ID supplier, double price)
        {
            Counter<ID> books = new Counter<ID>();
            books.Add(book);
            supply(books, supplier, price);
        }
        public void supply(Counter<ID> bookIds, ID supplierId, double price)
        {
            SuppliersService suppliers = new SuppliersService(_storage);
            ISupplier supplier = suppliers.get(supplierId);

            CatalogueService catalogue = new CatalogueService(_storage);

            Counter<IBook> books = new Counter<IBook>();

            foreach (var bookToNumber in bookIds)
            {
                ID book = bookToNumber.Key;
                int number = bookToNumber.Value;

                books.Set(catalogue.get(book), number);

                _storage.Inventory.add(book, number);
            }


            iSupplyRegisterEntry registerEntry = new iSupplyRegisterEntry(
                null, books, supplier, price, DateTime.Now);

            _storage.SupplyRegister.add(registerEntry);
        }

    }
}
