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
            book.Id = id;
            Assert.AreEqual(book.Id, catalogue.get(id).Id);

            Book identicalBook = new Book(null, name, author, description, price);
            Assert.ThrowsException<BookAlreadyExists>(() => catalogue.add(identicalBook));

            Book incorrectBook = new Book(null, name, author, description, -1);
            Assert.ThrowsException<IncorrectBookProperties>(() => catalogue.add(incorrectBook));
        }

        [TestMethod]
        public void testAddRemove()
        {

        }
    }
}
