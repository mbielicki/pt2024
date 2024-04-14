using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;

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

            Book book = DataGenerator.newBook();
            ID id = inventory.supply(book);

            Assert.AreEqual(1, inventory.count(id));

            inventory.supply(book);
            Assert.AreEqual(2, inventory.count(id));

            Book wrongBook = DataGenerator.copy(book);
            ID wrongId = new ID(id.Value + 1);
            wrongBook.Id = wrongId;

            Assert.ThrowsException<IdenticalItemWithDifferentIdExists>(() =>
            {
                inventory.supply(wrongBook);
            });  

        }

    }
}
