using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IBook book1 = DataGenerator.newBook();
            IBook book1copy = book1;
            IBook book2 = DataGenerator.newBook();
            IBook book3 = DataGenerator.newBook();

            IDataLayer storage = new DatabaseBookshopStorage();

            storage.Catalogue.add(book1);
            storage.Catalogue.add(book2);
            storage.Catalogue.add(book3);

            storage.Inventory.addOne((int)book1.Id);
            storage.Inventory.addOne((int)book1copy.Id);
            storage.Inventory.addOne((int)book2.Id);

            Assert.AreEqual(2, storage.Inventory.count((int)book1.Id));
            Assert.AreEqual(1, storage.Inventory.count((int)book2.Id));
            Assert.AreEqual(0, storage.Inventory.count((int)book3.Id));
        }

        [TestMethod]
        public void testRemove()
        {
            IBook book1 = DataGenerator.newBook();
            IBook book2 = DataGenerator.newBook();

            IDataLayer storage = new DatabaseBookshopStorage();

            storage.Catalogue.add(book1);
            storage.Catalogue.add(book2);

            storage.Inventory.addOne((int) book1.Id);
            storage.Inventory.addOne((int) book1.Id);
            storage.Inventory.addOne((int) book2.Id);

            storage.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(1, storage.Inventory.count((int) book1.Id));

            storage.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(0, storage.Inventory.count((int) book1.Id));

            storage.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(0, storage.Inventory.count((int) book1.Id));
        }
    }
}
