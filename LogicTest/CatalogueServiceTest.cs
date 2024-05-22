using Data.API;
using Data.Model.Entities;
using Logic;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class CatalogueServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;

            IBook book = DataGenerator.newBook();
            int id = catalogue.add(book);

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
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;

            IBook book = DataGenerator.newBook();
            int id = catalogue.add(book);

            IBook newBook = DataGenerator.newBook();
            newBook.Id = id;

            catalogue.update(newBook);
            Assert.AreEqual(newBook.Price, catalogue.get(id).Price);

            int nonexistentId = catalogue.getIds().Count + 1_000;
            newBook.Id = nonexistentId;
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.update(newBook));

            catalogue.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => catalogue.remove(id));
        }
        [TestMethod]
        public void testIdsDifferent()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;

            IBook book1 = DataGenerator.newBook();
            int id1 = catalogue.add(book1);

            IBook book2 = DataGenerator.newBook();
            int id2 = catalogue.add(book2);

            Assert.AreEqual(id1, id1);
            Assert.AreNotEqual(id1, id2 );
        }
    }
}
