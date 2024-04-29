using Bookshop.Model.Data.InMemoryStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;

namespace BookshopTest.DataTest.InMemoryStorageTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void testAddGet()
        {
            ID book1 = new ID(101);
            ID book1copy = new ID(101);
            ID book2 = new ID(102);
            ID book3 = new ID(103);

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
            ID book1 = new ID(101);
            ID book2 = new ID(102);

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
