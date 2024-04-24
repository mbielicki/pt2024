using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
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

            ICustomer customer = DataGenerator.newCustomer();
            customer.Id = storage.Customers.add(customer);
            IBook book = DataGenerator.newBook();
            ID bookId = storage.Catalogue.add(book); 

            Counter<IBook> books = new Counter<IBook>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(book);
            Invoice invoice = new Invoice(null, books, customer, price, now);
            ID id = storage.Invoices.add(invoice);

            Assert.AreEqual(price, invoices.get(id).Price);
        }
    }
}
