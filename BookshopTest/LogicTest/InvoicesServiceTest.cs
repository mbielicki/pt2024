using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InvoicesServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            InvoicesService invoices = new InvoicesService(storage);

            Customer customer = DataGenerator.newCustomer();
            customer.Id = storage.Customers.add(customer);
            ID bookId = storage.Catalogue.add(DataGenerator.newBook()); 

            Counter<ID> books = new Counter<ID>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(bookId);
            Invoice invoice = new Invoice(null, books, customer, price, now);
            ID id = storage.Invoices.add(invoice);

            Assert.AreEqual(price, invoices.get(id).Price);
        }
    }
}
