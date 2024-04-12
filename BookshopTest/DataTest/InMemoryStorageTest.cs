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
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            IBookshopStorage storage = new InMemoryStorage();

            BookID bookId = storage.add(book);
            Assert.AreEqual(book, storage.get(b => b.Id == bookId));
        }
        
        [TestMethod]
        public void testRemove()
        {
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            IBookshopStorage storage = new InMemoryStorage();
            BookID bookId = storage.add(book);
            storage.remove(bookId);
            Assert.IsNull(storage.get(b => b.Id == bookId));
        }

        [TestMethod]
        public void testUpdate()
        {
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            IBookshopStorage storage = new InMemoryStorage();
            BookID bookId = storage.add(book);

            double newPrice = 20;
            Book newBook = new Book(bookId, name, author, description, newPrice);
            storage.update(newBook);
            Assert.AreEqual(book, storage.get(b => b.Id == bookId));
        }
    }
}
