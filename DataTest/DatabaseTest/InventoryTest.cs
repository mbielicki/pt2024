using Data.API;
using BookshopTest.Data.Database;
using Data.Database;
using Data.Model.Entities;

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

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            dataLayer.Catalogue.add(book1);
            dataLayer.Catalogue.add(book2);
            dataLayer.Catalogue.add(book3);

            dataLayer.Inventory.addOne((int)book1.Id);
            dataLayer.Inventory.addOne((int)book1copy.Id);
            dataLayer.Inventory.addOne((int)book2.Id);

            Assert.AreEqual(2, dataLayer.Inventory.count((int)book1.Id));
            Assert.AreEqual(1, dataLayer.Inventory.count((int)book2.Id));
            Assert.AreEqual(0, dataLayer.Inventory.count((int)book3.Id));
        }

        [TestMethod]
        public void testRemove()
        {
            IBook book1 = DataGenerator.newBook();
            IBook book2 = DataGenerator.newBook();

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            dataLayer.Catalogue.add(book1);
            dataLayer.Catalogue.add(book2);

            dataLayer.Inventory.addOne((int) book1.Id);
            dataLayer.Inventory.addOne((int) book1.Id);
            dataLayer.Inventory.addOne((int) book2.Id);

            dataLayer.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(1, dataLayer.Inventory.count((int) book1.Id));

            dataLayer.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(0, dataLayer.Inventory.count((int) book1.Id));

            dataLayer.Inventory.removeOne((int) book1.Id);
            Assert.AreEqual(0, dataLayer.Inventory.count((int) book1.Id));
        }
    }
}
