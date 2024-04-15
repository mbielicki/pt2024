using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;
using Bookshop.Logic.Suppliers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class BuyServiceTest
    {
        [TestMethod]
        public void testCheckPrice()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);
            BuyService buyService = new BuyService(storage);

            Book book1 = DataGenerator.newBook();
            ID id1 = catalogue.add(book1);

            Book book2 = DataGenerator.newBook();
            ID id2 = catalogue.add(book2);

            Counter<ID> books = new Counter<ID>();
            books.Add(id1);
            books.Add(id2);
            books.Add(id2);
            double expectedPrice = (double)(book1.Price + book2.Price * 2);

            double buyPrice = buyService.checkPrice(books);

            Assert.AreEqual(expectedPrice, buyPrice);
        }

        [TestMethod]
        public void testBuy()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);
            CustomersService customersService = new CustomersService(storage);
            InventoryService inventoryService = new InventoryService(storage);
            SuppliersService suppliersService = new SuppliersService(storage);
            BuyService buyService = new BuyService(storage);

            // Make shopping list
            Book book1 = DataGenerator.newBook();
            ID bookId1 = catalogue.add(book1);

            Book book2 = DataGenerator.newBook();
            ID bookId2 = catalogue.add(book2);

            Counter<ID> books = new Counter<ID>();
            books.Add(bookId1);
            books.Add(bookId2);
            books.Add(bookId2);

            // Make customer
            Customer customer = DataGenerator.newCustomer();
            ID customerId = customersService.add(customer);

            // Make inventory
            Supplier supplier = DataGenerator.newSupplier();
            ID supplierId = suppliersService.add(supplier);
            inventoryService.supply(bookId1, supplierId, 100);
            inventoryService.supply(bookId2, supplierId, 100);

            // Test NotEnoughItemsInInventory
            Assert.ThrowsException<NotEnoughItemsInInventory>(() =>
            {
                buyService.buy(customerId, books);
            });

            // Supply 
            inventoryService.supply(bookId2, supplierId, 100);
            ID invoiceId = buyService.buy(customerId, books);

            // Check invoice
            InvoicesService invoicesService = new InvoicesService(storage);
            Invoice invoice = invoicesService.get(invoiceId);

            double price = buyService.checkPrice(books);
            Assert.AreEqual(price, invoice.Price);
        }

    }
}
