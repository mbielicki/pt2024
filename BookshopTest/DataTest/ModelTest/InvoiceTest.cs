using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void testInvoiceInit()
        {
            Customer customer = DataGenerator.newCustomer();
            ID bookId = new ID(321);
            ID invoiceId = new ID(456);

            Counter<ID> books = new Counter<ID>();
            books.Add(bookId);
            double price = 50;
            DateTime now = DateTime.Now;

            Invoice invoice = new Invoice(invoiceId, books, customer, price, now);

            Assert.AreEqual(invoiceId, invoice.Id);
            Assert.AreEqual(customer, invoice.Customer);
            Assert.AreEqual(1, invoice.Books.Count(bookId));
            Assert.AreEqual(price, invoice.Price);
            Assert.AreEqual(now, invoice.DateTime);
        }
    }
}
