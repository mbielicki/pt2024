using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Data.Database;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class CatalogueTest
    {
        [TestMethod]
        public void testAddGet()
        {
            iBook book = DataGenerator.newBook();

            IBookshopStorage storage = new DatabaseBookshopStorage();

            ID bookId = storage.Catalogue.add(book);
            Assert.AreEqual(book, storage.Catalogue.get(b => b.Id.Equals(bookId)));
        }

        [TestMethod]
        public void testRemove()
        {
            iBook book = DataGenerator.newBook();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            ID bookId = storage.Catalogue.add(book);
            storage.Catalogue.remove(bookId);
            Assert.IsNull(storage.Catalogue.get(b => b.Id.Equals(bookId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            iBook book = DataGenerator.newBook();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            ID bookId = storage.Catalogue.add(book);

            double newPrice = 20;
            iBook newBook = new iBook(bookId, book.Title, book.Author, book.Description, newPrice);
            storage.Catalogue.update(newBook);
            Assert.AreEqual(newPrice, storage.Catalogue.get(b => b.Id.Equals(bookId)).Price);
        }
    }
}
