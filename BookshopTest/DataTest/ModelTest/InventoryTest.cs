using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void testInventory()
        {
            int bookId = 321;

            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Count(bookId));

            inventory.Add(bookId);
            Assert.AreEqual(1, inventory.Count(bookId));

            inventory.Add(bookId);
            Assert.AreEqual(2, inventory.Count(bookId));

            inventory.Remove(bookId);
            Assert.AreEqual(1, inventory.Count(bookId));

            inventory.Remove(bookId);
            Assert.ThrowsException<KeyNotFoundException>(() => inventory.Remove(bookId));

        }
    }
}
