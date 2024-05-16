using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void testAddGet()
        {
            int book1 = 101;
            int book1copy = 101;
            int book2 = 102;
            int book3 = 103;

            IBookshopStorage storage = new InMemoryBookshopStorage();

            storage.Inventory.addOne(book1);
            storage.Inventory.addOne(book1copy);
            storage.Inventory.addOne(book2);

            Assert.AreEqual(2, storage.Inventory.count(book1));
            Assert.AreEqual(1, storage.Inventory.count(book2));
            Assert.AreEqual(0, storage.Inventory.count(book3));
        }

        [TestMethod]
        public void testRemove()
        {
            int book1 = 101;
            int book2 = 102;

            IBookshopStorage storage = new InMemoryBookshopStorage();

            storage.Inventory.addOne(book1);
            storage.Inventory.addOne(book1);
            storage.Inventory.addOne(book2);

            storage.Inventory.removeOne(book1);
            Assert.AreEqual(1, storage.Inventory.count(book1));

            storage.Inventory.removeOne(book1);
            Assert.AreEqual(0, storage.Inventory.count(book1));

            storage.Inventory.removeOne(book1);
            Assert.AreEqual(0, storage.Inventory.count(book1));
        }
    }
}
