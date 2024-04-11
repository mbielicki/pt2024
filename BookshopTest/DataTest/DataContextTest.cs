using Bookshop.Data;

namespace BookshopTest.DataTest
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void testDataContext()
        {
            int bookId = 321;
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(bookId, name, author, description, price);


            int id = 123;
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(id, firstName, lastName, address, contactInfo);

            int invoiceId = 456;
            List<Book> books = new List<Book>();
            DateTime now = DateTime.Now;

            books.Add(book);
            Invoice invoice = new Invoice(invoiceId, books, customer, price, now);

            BookshopDataContext bookshop = new BookshopDataContext();
            bookshop.Catalogue.Add(book);
            bookshop.Inventory.Add(book);
            bookshop.Inventory.Add(book);
            bookshop.Customers.Add(customer);
            bookshop.Invoices.Add(invoice);

            Assert.IsFalse(bookshop.Catalogue.Add(book));
            Assert.AreEqual(2, bookshop.Inventory.Count(book));
            Assert.AreEqual(firstName, bookshop.Customers[0].FirstName);
            Assert.AreEqual(now, bookshop.Invoices[0].DateTime);

        }
    }
}
