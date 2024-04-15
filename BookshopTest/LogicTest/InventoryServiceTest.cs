using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
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
            IBookshopStorage storage = new FileSystemBookshopStorage();
            InventoryService inventory = new InventoryService(storage);
            CatalogueService catalogue = new CatalogueService(storage);
            SuppliersService suppliers = new SuppliersService(storage);

            // Books
            Counter<ID> books = new Counter<ID>();
            Book book = DataGenerator.newBook();
            books.Add(catalogue.add(book));

            // Supplier
            Supplier supplier = DataGenerator.newSupplier();
            ID supplierId = suppliers.add(supplier);

            // Supply
            inventory.supply(books, supplierId, 100);
            ID id = books.Keys[0];

            Assert.AreEqual(1, inventory.count(id));

            inventory.supply(id, supplierId, 100);
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
