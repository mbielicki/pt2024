using Data.API;
using Data.Model.Entities;
using BookshopTest.Data.Database;
using Data.Database;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class CatalogueTest
    {
        [TestMethod]
        public void testAddGet()
        {
            SimpleBook book = DataGenerator.newBook();

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            int bookId = dataLayer.Catalogue.add(book);
            Assert.AreEqual(book.Description, dataLayer.Catalogue.get(b => b.Id.Equals(bookId)).Description);

            dataLayer.Catalogue.remove(bookId);
        }

        [TestMethod]
        public void testRemove()
        {
            SimpleBook book = DataGenerator.newBook();

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());
            int bookId = dataLayer.Catalogue.add(book);
            dataLayer.Catalogue.remove(bookId);
            Assert.IsNull(dataLayer.Catalogue.get(b => b.Id.Equals(bookId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            SimpleBook book = DataGenerator.newBook();

            IDataLayer datalayer = new DatabaseDataLayer(TestConnectionString.Get());
            int bookId = datalayer.Catalogue.add(book);

            double newPrice = 20;
            SimpleBook newBook = new SimpleBook(bookId, book.Title, book.Author, book.Description, newPrice);
            datalayer.Catalogue.update(newBook);
            Assert.AreEqual(newPrice, datalayer.Catalogue.get(b => b.Id.Equals(bookId)).Price);

            datalayer.Catalogue.remove(bookId);
        }
    }
}
