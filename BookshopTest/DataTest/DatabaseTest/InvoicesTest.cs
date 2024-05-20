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

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            dataLayer.Customers.add(customer);
            foreach (var book in books)
                dataLayer.Catalogue.add(book.Key);

            int invoiceId = dataLayer.Invoices.add(invoice);

            Assert.AreEqual(invoice.DateTime.ToString(), dataLayer.Invoices.get(i => i.Id.Equals(invoiceId)).DateTime.ToString());
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

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            dataLayer.Customers.add(customer);
            foreach (var book in books)
                dataLayer.Catalogue.add(book.Key);

            int invoiceId = dataLayer.Invoices.add(invoice);
            dataLayer.Invoices.remove(invoiceId);
            Assert.IsNull(dataLayer.Invoices.get(i => i.Id.Equals(invoiceId)));
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

            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            dataLayer.Customers.add(customer);
            foreach (var book in books)
                dataLayer.Catalogue.add(book.Key);

            int invoiceId = dataLayer.Invoices.add(invoice);

            double newPrice = 40;
            SimpleInvoice newInvoice = new SimpleInvoice(invoiceId, books, customer, newPrice, dateTime);

            dataLayer.Invoices.update(newInvoice);
            Assert.AreEqual(newPrice, dataLayer.Invoices.get(i => i.Id.Equals(invoiceId)).Price);
        }
    }
}
