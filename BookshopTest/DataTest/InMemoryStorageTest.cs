using Bookshop.Data;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest
{
    [TestClass]
    public class InMemoryStorageTest
    {
        [TestMethod]
        public void testAddGet()
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
        
        [TestMethod]
        public void testRemove()
        {
            int bookId = 321;
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);

            IStorage storage = new InMemoryStorage();
            storage.add(book);
            storage.remove(bookId);
            Assert.IsNull(storage.get(bookId));
        }

        [TestMethod]
        public void testUpdate()
        {
            int bookId = 321;
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);

            IStorage storage = new InMemoryStorage();
            storage.add(book);

            double newPrice = 20;
            Book newBook = new Book(bookId, name, author, description, newPrice);
            storage.update(newBook);
            Assert.AreEqual(book, storage.get(bookId));
        }
    }
}
