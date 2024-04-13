using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class CatalogueServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            IService<Book> catalogue = new CatalogueService(storage);

            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            ID id = catalogue.add(book);
            Assert.AreEqual(id, catalogue.getIds()[0]);

            Book identicalBook = new Book(null, name, author, description, price);
            Assert.ThrowsException<ItemAlreadyExists>(() => catalogue.add(identicalBook));

            Book incorrectBook = new Book(null, name, author, description, -1);
            Assert.ThrowsException<InvalidItemProperties>(() => catalogue.add(incorrectBook));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            IService<Book> catalogue = new CatalogueService(storage);

            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            ID id = catalogue.add(book);

            Book newBook = new Book(id, name, author, description, price + 10);
            catalogue.update(newBook);
            Assert.AreEqual(newBook.Price, catalogue.get(id).Price);

            catalogue.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.remove(id));
        }
    }
}
