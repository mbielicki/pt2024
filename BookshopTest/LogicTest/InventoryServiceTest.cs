using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic;
using Bookshop.Model.Logic.Catalogue;
using Bookshop.Model.Logic.Suppliers;

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
            IBook book = DataGenerator.newBook();
            books.Add(catalogue.add(book));

            // Supplier
            ISupplier supplier = DataGenerator.newSupplier();
            ID supplierId = suppliers.add(supplier);

            // Supply
            inventory.supply(books, supplierId, 100);
            ID id = books.Keys[0];

            Assert.AreEqual(1, inventory.count(id));

            inventory.supply(id, supplierId, 100);
            Assert.AreEqual(2, inventory.count(id));

            IBook wrongBook = DataGenerator.copy(book);
            ID wrongId = new ID(id.Value + 1);

            Assert.ThrowsException<ItemIdNotFound>(() =>
            {
                inventory.supply(wrongId, supplierId, 100);
            });  

        }

    }
}
