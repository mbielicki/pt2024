using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using BookshopTest.Data.InMemoryMockStorage;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SupplyRegisterServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IEventService<ISupply> register = logic.SupplyService;

            ISupplier supplier = DataGenerator.newSupplier();
            supplier.Id = dataLayer.Suppliers.add(supplier);
            IBook book = DataGenerator.newBook();
            int bookId = dataLayer.Catalogue.add(book);

            Counter<IBook> books = new Counter<IBook>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(book);
            SimpleSupply entry = new SimpleSupply(null, books, supplier, price, now);
            int id = dataLayer.Supply.add(entry);


            Assert.AreEqual(price, register.get(id).Price);
        }
    }
}
