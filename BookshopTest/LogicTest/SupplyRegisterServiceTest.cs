using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
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
            IBookshopStorage storage = new FileSystemBookshopStorage();
            SupplyRegisterService register = new SupplyRegisterService(storage);

            Supplier supplier = DataGenerator.newSupplier();
            ID bookId = new ID(321);

            Counter<ID> books = new Counter<ID>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(bookId);
            SupplyRegisterEntry entry = new SupplyRegisterEntry(null, books, supplier, price, now);
            ID id = storage.SupplyRegister.add(entry);


            Assert.AreEqual(price, register.get(id).Price);
        }
    }
}
