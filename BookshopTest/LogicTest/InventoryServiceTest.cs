using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
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
            Counter<Book> books = new Counter<Book>();
            Book book = DataGenerator.newBook();
            books.add(book);

            // Supplier
            SuppliersService suppliers = new SuppliersService(storage);
            Supplier supplier = DataGenerator.newSupplier();
            ID supplierId = suppliers.add(supplier);

            // Supply
            Counter<ID> ids = inventory.supply(books, supplierId, 100);
            ID id = ids.Keys[0];

            Assert.AreEqual(1, inventory.count(id));

            ids = inventory.supply(book, supplierId, 100);
            Assert.AreEqual(2, inventory.count(id));

            Book wrongBook = DataGenerator.copy(book);
            ID wrongId = new ID(id.Value + 1);
            wrongBook.Id = wrongId;

            Assert.ThrowsException<IdenticalItemWithDifferentIdExists>(() =>
            {
                inventory.supply(wrongBook, supplierId, 100);
            });  

        }

    }
}
