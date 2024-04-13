using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest
{
    [TestClass]
    public class InMemoryStorageTest
    {
        [TestMethod]
        public void testAddGet()
        {
            Book book = DataGenerator.newBook();

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID bookId = storage.Catalogue.add(book);
            Assert.AreEqual(book, storage.Catalogue.get(b => b.Id == bookId));
        }
        
        [TestMethod]
        public void testRemove()
        {
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            IBookshopStorage storage = new InMemoryBookshopStorage();
            ID bookId = storage.Catalogue.add(book);
            storage.Catalogue.remove(bookId);
            Assert.IsNull(storage.Catalogue.get(b => b.Id == bookId));
        }

        [TestMethod]
        public void testUpdate()
        {
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            IBookshopStorage storage = new InMemoryBookshopStorage();
            ID bookId = storage.Catalogue.add(book);

            double newPrice = 20;
            Book newBook = new Book(bookId, name, author, description, newPrice);
            storage.Catalogue.update(newBook);
            Assert.AreEqual(book, storage.Catalogue.get(b => b.Id == bookId));
        }
    }
}
