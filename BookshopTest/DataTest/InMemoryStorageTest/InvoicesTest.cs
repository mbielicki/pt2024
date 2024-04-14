using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.InMemoryStorage
{
    [TestClass]
    public class InvoicesTest
    {
        [TestMethod]
        public void testAddGet()
        {
            Counter<ID> books = new Counter<ID>();
            books.Add(new ID(123));
            ID customer = new ID(321);
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);
            Assert.AreEqual(invoice.DateTime, storage.Invoices.get(i => i.Id == invoiceId).DateTime);
        }

        [TestMethod]
        public void testRemove()
        {
            Counter<ID> books = new Counter<ID>();
            books.Add(new ID(123));
            ID customer = new ID(321);
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);
            storage.Invoices.remove(invoiceId);
            Assert.IsNull(storage.Invoices.get(i => i.Id == invoiceId));
        }

        [TestMethod]
        public void testUpdate()
        {
            Counter<ID> books = new Counter<ID>();
            books.Add(new ID(123));
            ID customer = new ID(321);
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);

            double newPrice = 40;
            Invoice newInvoice = new Invoice(invoiceId, books, customer, newPrice, dateTime);

            storage.Invoices.update(newInvoice);
            Assert.AreEqual(newPrice, storage.Invoices.get(i => i.Id == invoiceId).Price);
        }
    }
}
