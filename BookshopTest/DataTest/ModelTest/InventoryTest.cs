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
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);

            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Count(book));

            inventory.Add(book);
            Assert.AreEqual(1, inventory.Count(book));

            inventory.Add(book);
            Assert.AreEqual(2, inventory.Count(book));

            inventory.Remove(book);
            Assert.AreEqual(1, inventory.Count(book));

            inventory.Remove(book);
            Assert.ThrowsException<NoSuchBookInInventory>(() => inventory.Remove(book));

        }
    }
}
