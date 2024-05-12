using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void testInvoiceInit()
        {
            Customer customer = DataGenerator.newCustomer();
            IBook book = DataGenerator.newBook();
            ID invoiceId = new ID(456);

            Counter<IBook> books = new Counter<IBook>();
            books.Add(book);
            double price = 50;
            DateTime now = DateTime.Now;

            IInvoice invoice = new Invoice(invoiceId, books, customer, price, now);

            Assert.AreEqual(invoiceId, invoice.Id);
            Assert.AreEqual(customer, invoice.Customer);
            Assert.AreEqual(1, invoice.Books.Count(book));
            Assert.AreEqual(price, invoice.Price);
            Assert.AreEqual(now, invoice.DateTime);
        }
    }
}
