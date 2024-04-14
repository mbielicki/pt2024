using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SupplyRegisterServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID supplierId = new ID(123);
            ID bookId = new ID(321);

            Counter<ID> books = new Counter<ID>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(bookId);
            SupplyRegisterEntry entry = new SupplyRegisterEntry(null, books, supplierId, price, now);
            ID id = storage.SupplyRegister.add(entry);

            SupplyRegisterService register = new SupplyRegisterService(storage);

            List<ID> ids = register.getIds();
            Assert.AreEqual(price, register.get(ids[0]).Price);
        }
    }
}
