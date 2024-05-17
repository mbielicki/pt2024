using BookshopTest.Data.SampleMockStorage;
using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Suppliers;
using BookshopTest.Data.InMemoryMockStorage;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InventoryServiceTest
    {
        [TestMethod]
        public void testSupplyNewBook()
        {
            //IBookshopStorage storage = new SampleMockStorage();
            IBookshopStorage storage = new InMemoryMockStorage();
            InventoryService inventory = new InventoryService(storage);
            CatalogueService catalogue = new CatalogueService(storage);
            SuppliersService suppliers = new SuppliersService(storage);

            // Books
            Counter<int> books = new Counter<int>();
            IBook book = DataGenerator.newBook();
            books.Add(catalogue.add(book));

            // Supplier
            ISupplier supplier = DataGenerator.newSupplier();
            int supplierId = suppliers.add(supplier);

            // Supply
            inventory.supply(books, supplierId, 100);
            int id = books.Keys[0];

            Assert.AreEqual(1, inventory.count(id));

            inventory.supply(id, supplierId, 100);
            Assert.AreEqual(2, inventory.count(id));

            IBook wrongBook = DataGenerator.copy(book);
            int wrongId = id + 1;

            Assert.ThrowsException<ItemIdNotFound>(() =>
            {
                inventory.supply(wrongId, supplierId, 100);
            });  

        }

    }
}
