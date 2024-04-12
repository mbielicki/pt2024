using Bookshop.Data;
using Bookshop.Data.Model;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class CatalogueServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IStorage storage = new InMemoryStorage();
            IService catalogue = new CatalogueService(storage);

            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            int id = catalogue.add(book);
            Assert.AreEqual(id, catalogue.get(id).Id);

            Book identicalBook = new Book(null, name, author, description, price);
            Assert.ThrowsException<BookAlreadyExists>(() => catalogue.add(identicalBook));

            Book incorrectBook = new Book(null, name, author, description, -1);
            Assert.ThrowsException<InvalidBookProperties>(() => catalogue.add(incorrectBook));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IStorage storage = new InMemoryStorage();
            IService catalogue = new CatalogueService(storage);

            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            int id = catalogue.add(book);

            Book newBook = new Book(id, name, author, description, price + 10);
            catalogue.update(newBook);
            Assert.AreEqual(newBook.Price, catalogue.get(id).Price);

            catalogue.remove(id);
            Assert.ThrowsException<BookIdNotFound>(() => catalogue.remove(id));
        }
    }
}
