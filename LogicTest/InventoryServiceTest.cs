using Data.API;
using Logic.Model;
using Logic.Model.Entities;
using Logic;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InventoryServiceTest
    {
        [TestMethod]
        public void testSupplyNewBook()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;
            IInventoryService inventory = logic.InventoryService;
            IService<ISupplier> suppliers = logic.SuppliersService;

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

            Assert.ThrowsException<BookIdNotFound>(() =>
            {
                inventory.supply(wrongId, supplierId, 100);
            });  

        }

    }
}
