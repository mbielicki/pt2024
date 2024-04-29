using Bookshop.Model.Data.InMemoryStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;

namespace BookshopTest.DataTest.InMemoryStorage
{
    [TestClass]
    public class InvoicesTest
    {
        [TestMethod]
        public void testAddGet()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            Customer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);
            Assert.AreEqual(invoice.DateTime, storage.Invoices.get(i => i.Id.Equals(invoiceId)).DateTime);
        }

        [TestMethod]
        public void testRemove()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            Customer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);
            storage.Invoices.remove(invoiceId);
            Assert.IsNull(storage.Invoices.get(i => i.Id.Equals(invoiceId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(DataGenerator.newBook());
            Customer customer = DataGenerator.newCustomer();
            double price = 40;
            DateTime dateTime = DateTime.Now;

            Invoice invoice = new Invoice(null, books, customer, price, dateTime);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID invoiceId = storage.Invoices.add(invoice);

            double newPrice = 40;
            Invoice newInvoice = new Invoice(invoiceId, books, customer, newPrice, dateTime);

            storage.Invoices.update(newInvoice);
            Assert.AreEqual(newPrice, storage.Invoices.get(i => i.Id.Equals(invoiceId)).Price);
        }
    }
}
