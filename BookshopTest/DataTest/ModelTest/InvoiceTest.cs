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

            List<ID> books = new List<ID>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(bookId);
            Invoice invoice = new Invoice(invoiceId, books, customerId, price, now);

            Assert.AreEqual(invoiceId, invoice.Id);
            Assert.AreEqual(customerId, invoice.Customer);
            Assert.AreEqual(bookId, invoice.Books[0]);
            Assert.AreEqual(price, invoice.Price);
            Assert.AreEqual(now, invoice.DateTime);
        }
    }
}
