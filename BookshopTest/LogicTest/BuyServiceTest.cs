using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class BuyServiceTest
    {
        [TestMethod]
        public void testCheckPrice()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            Book book1 = DataGenerator.newBook();
            ID id1 = catalogue.add(book1);

            Book book2 = DataGenerator.newBook();
            ID id2 = catalogue.add(book2);

            Counter<ID> books = new Counter<ID>();
            books.add(id1);
            books.add(id2);
            books.add(id2);
            double expectedPrice = (double)(book1.Price + book2.Price * 2);

            BuyService buyService = new BuyService(storage);
            double buyPrice = buyService.checkPrice(books);

            Assert.AreEqual(expectedPrice, buyPrice);
        }

        [TestMethod]
        public void testBuy()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            // Make shopping list
            Book book1 = DataGenerator.newBook();
            ID id1 = catalogue.add(book1);

            Book book2 = DataGenerator.newBook();
            ID id2 = catalogue.add(book2);

            Counter<ID> books = new Counter<ID>();
            books.add(id1);
            books.add(id2);
            books.add(id2);

            // Make customer
            CustomersService customersService = new CustomersService(storage);

            Customer customer = DataGenerator.newCustomer();
            ID customerId = customersService.add(customer);

            // Make inventory
            InventoryService inventoryService = new InventoryService(storage);
            inventoryService.supply(book1);
            inventoryService.supply(book2);

            // Test NotEnoughItemsInInventory
            BuyService buyService = new BuyService(storage);
            Assert.ThrowsException<NotEnoughItemsInInventory>(() =>
            {
                buyService.buy(customerId, books);
            });

            // Supply 
            inventoryService.supply(book2);
            ID invoiceId = buyService.buy(customerId, books);

            // Check invoice
            InvoicesService invoicesService = new InvoicesService(storage);
            Invoice invoice = invoicesService.get(invoiceId);

            double price = buyService.checkPrice(books);
            Assert.AreEqual(price, invoice.Price);
        }

    }
}
