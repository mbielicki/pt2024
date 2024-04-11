using Bookshop.Data;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest
{
    [TestClass]
    public class InMemoryStorageTest
    {
        [TestMethod]
        public void AddGet()
        {
            int bookId = 321;
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);

            IStorage storage = new InMemoryStorage();
            storage.add(book);
            Assert.AreEqual(book, storage.get(bookId));
        }
    }
}
