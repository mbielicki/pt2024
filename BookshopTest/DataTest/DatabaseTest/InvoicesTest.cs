using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Data.Database;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class InvoicesTest
    {
        [TestMethod]
        public void testAddGet()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            SimpleCustomer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            SimpleInvoice invoice = new SimpleInvoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new DatabaseBookshopStorage();

            int invoiceId = storage.Invoices.add(invoice);
            Assert.AreEqual(invoice.DateTime, storage.Invoices.get(i => i.Id.Equals(invoiceId)).DateTime);
        }

        [TestMethod]
        public void testRemove()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            SimpleCustomer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            SimpleInvoice invoice = new SimpleInvoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new DatabaseBookshopStorage();

            int invoiceId = storage.Invoices.add(invoice);
            storage.Invoices.remove(invoiceId);
            Assert.IsNull(storage.Invoices.get(i => i.Id.Equals(invoiceId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            SimpleCustomer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            SimpleInvoice invoice = new SimpleInvoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new DatabaseBookshopStorage();

            int invoiceId = storage.Invoices.add(invoice);

            double newPrice = 40;
            SimpleInvoice newInvoice = new SimpleInvoice(invoiceId, books, customer, newPrice, dateTime);

            storage.Invoices.update(newInvoice);
            Assert.AreEqual(newPrice, storage.Invoices.get(i => i.Id.Equals(invoiceId)).Price);
        }
    }
}
