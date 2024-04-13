using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void testInvoiceInit()
        {
            ID customerId = new ID(123);
            ID bookId = new ID(321);
            ID invoiceId = new ID(456);

            Counter<ID> books = new Counter<ID>();
            books.add(bookId);
            double price = 50;
            DateTime now = DateTime.Now;

            Invoice invoice = new Invoice(invoiceId, books, customerId, price, now);

            Assert.AreEqual(invoiceId, invoice.Id);
            Assert.AreEqual(customerId, invoice.Customer);
            Assert.AreEqual(1, invoice.Books.count(bookId));
            Assert.AreEqual(price, invoice.Price);
            Assert.AreEqual(now, invoice.DateTime);
        }
    }
}
