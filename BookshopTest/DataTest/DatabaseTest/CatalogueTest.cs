using Bookshop.Data.API;
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
            SimpleBook book = DataGenerator.newBook();

            IDataLayer storage = new DatabaseBookshopStorage();

            int bookId = storage.Catalogue.add(book);
            Assert.AreEqual(book.Description, storage.Catalogue.get(b => b.Id.Equals(bookId)).Description);

            storage.Catalogue.remove(bookId);
        }

        [TestMethod]
        public void testRemove()
        {
            SimpleBook book = DataGenerator.newBook();

            IDataLayer storage = new DatabaseBookshopStorage();
            int bookId = storage.Catalogue.add(book);
            storage.Catalogue.remove(bookId);
            Assert.IsNull(storage.Catalogue.get(b => b.Id.Equals(bookId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            SimpleBook book = DataGenerator.newBook();

            IDataLayer storage = new DatabaseBookshopStorage();
            int bookId = storage.Catalogue.add(book);

            double newPrice = 20;
            SimpleBook newBook = new SimpleBook(bookId, book.Title, book.Author, book.Description, newPrice);
            storage.Catalogue.update(newBook);
            Assert.AreEqual(newPrice, storage.Catalogue.get(b => b.Id.Equals(bookId)).Price);

            storage.Catalogue.remove(bookId);
        }
    }
}
