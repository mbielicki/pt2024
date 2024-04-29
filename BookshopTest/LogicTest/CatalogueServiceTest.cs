using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic;
using Bookshop.Model.Logic.Catalogue;

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

            IBook book = DataGenerator.newBook();
            ID id = catalogue.add(book);

            Assert.AreEqual(book.Author, catalogue.get(id).Author);

            IBook identicalBook = DataGenerator.copy(book);
            Assert.ThrowsException<ItemAlreadyExists>(() => catalogue.add(identicalBook));

            IBook incorrectBook = DataGenerator.newBook();
            incorrectBook.Price = -1;
            Assert.ThrowsException<InvalidItemProperties>(() => catalogue.add(incorrectBook));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            IBook book = DataGenerator.newBook();
            ID id = catalogue.add(book);

            IBook newBook = DataGenerator.newBook();
            newBook.Id = id;

            catalogue.update(newBook);
            Assert.AreEqual(newBook.Price, catalogue.get(id).Price);

            ID nonexistentId = new ID(catalogue.getIds().Count + 1_000);
            newBook.Id = nonexistentId;
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.update(newBook));

            catalogue.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.remove(id));
        }
        [TestMethod]
        public void testIdsDifferent() 
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            IBook book1 = DataGenerator.newBook();
            ID id1 = catalogue.add(book1);

            IBook book2 = DataGenerator.newBook();
            ID id2 = catalogue.add(book2);

            Assert.AreEqual(id1, new ID(id1.Value));
            Assert.AreNotEqual(id1, id2 );
        }
    }
}
