using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InvoicesServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID customerId = new ID(123);
            ID bookId = new ID(321);
            ID invoiceId = new ID(456);

            Counter<ID> books = new Counter<ID>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.add(bookId);
            Invoice invoice = new Invoice(null, books, customerId, price, now);
            ID id = storage.Invoices.add(invoice);

            InvoicesService invoices = new InvoicesService(storage);

            List<ID> ids = invoices.getIds();
            Assert.AreEqual(price, invoices.get(ids[0]).Price);
        }
    }
}
