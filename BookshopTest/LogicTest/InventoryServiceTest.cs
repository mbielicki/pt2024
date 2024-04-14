using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Suppliers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InventoryServiceTest
    {
        [TestMethod]
        public void testSupplyNewBook()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            InventoryService inventory = new InventoryService(storage);

            // Books
            CatalogueService catalogue = new CatalogueService(storage);
            Counter<ID> books = new Counter<ID>();
            Book book = DataGenerator.newBook();
            books.Add(catalogue.add(book));

            // Supplier
            SuppliersService suppliers = new SuppliersService(storage);
            Supplier supplier = DataGenerator.newSupplier();
            ID supplierId = suppliers.add(supplier);

            // Supply
            Counter<ID> ids = inventory.supply(books, supplierId, 100);
            ID id = ids.Keys[0];

            Assert.AreEqual(1, inventory.count(id));

            ids = inventory.supply(id, supplierId, 100);
            Assert.AreEqual(2, inventory.count(id));

            Book wrongBook = DataGenerator.copy(book);
            ID wrongId = new ID(id.Value + 1);

            Assert.ThrowsException<ItemIdNotFound>(() =>
            {
                inventory.supply(wrongId, supplierId, 100);
            });  

        }

    }
}
