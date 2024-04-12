using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void testInvoiceInit()
        {
            int customerId = 123;
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;
            Customer customer = new Customer(customerId, firstName, lastName, address, contactInfo);

            BookID bookId = new BookID(321);
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);

            int invoiceId = 456;
            List<Book> books = new List<Book>();
            DateTime now = DateTime.Now;

            books.Add(book);
            Invoice invoice = new Invoice(invoiceId, books, customer, price, now);

            Assert.AreEqual(invoiceId, invoice.Id);
            Assert.AreEqual(customerId, invoice.Customer.Id);
            Assert.AreEqual(book.Name, invoice.Books[0].Name);
            Assert.AreEqual(price, invoice.Price);
            Assert.AreEqual(now, invoice.DateTime);
        }
    }
}
