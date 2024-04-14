using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
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
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            Book book = DataGenerator.newBook();
            ID id = catalogue.add(book);

            Assert.AreEqual(id, catalogue.getIds()[0]);

            Book identicalBook = DataGenerator.copy(book);
            Assert.ThrowsException<ItemAlreadyExists>(() => catalogue.add(identicalBook));

            Book incorrectBook = DataGenerator.newBook();
            incorrectBook.Price = -1;
            Assert.ThrowsException<InvalidItemProperties>(() => catalogue.add(incorrectBook));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            Book book = DataGenerator.newBook();
            ID id = catalogue.add(book);

            Book newBook = DataGenerator.newBook();
            newBook.Id = id;

            catalogue.update(newBook);
            Assert.AreEqual(newBook.Price, catalogue.get(id).Price);

            catalogue.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.remove(id));
        }
        [TestMethod]
        public void testIdsDifferent() 
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            Book book1 = DataGenerator.newBook();
            ID id1 = catalogue.add(book1);

            Book book2 = DataGenerator.newBook();
            ID id2 = catalogue.add(book2);

            Assert.AreEqual(id1, new ID(id1.Value));
            Assert.AreNotEqual(id1, id2 );
        }
    }
}
