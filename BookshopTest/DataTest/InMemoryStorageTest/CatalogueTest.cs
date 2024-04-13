using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.InMemoryStorage
{
    [TestClass]
    public class CatalogueTest
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
            Book book = DataGenerator.newBook();

            IBookshopStorage storage = new InMemoryBookshopStorage();
            ID bookId = storage.Catalogue.add(book);
            storage.Catalogue.remove(bookId);
            Assert.IsNull(storage.Catalogue.get(b => b.Id == bookId));
        }

        [TestMethod]
        public void testUpdate()
        {
            Book book = DataGenerator.newBook();

            IBookshopStorage storage = new InMemoryBookshopStorage();
            ID bookId = storage.Catalogue.add(book);

            double newPrice = 20;
            Book newBook = new Book(bookId, book.Title, book.Author, book.Description, newPrice);
            storage.Catalogue.update(newBook);
            Assert.AreEqual(newPrice, storage.Catalogue.get(b => b.Id == bookId).Price);
        }
    }
}
