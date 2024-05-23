using Data.API;
using Logic.Model;
using Logic.Model.Entities;
using Logic;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class BuyServiceTest
    {
        [TestMethod]
        public void testCheckPrice()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;
            IBuyService buyService = logic.BuyService;

            IBook book1 = DataGenerator.newBook();
            int id1 = catalogue.add(book1);

            IBook book2 = DataGenerator.newBook();
            int id2 = catalogue.add(book2);

            Counter<int> books = new Counter<int>();
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
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<IBook> catalogue = logic.CatalogueService;
            IBuyService buyService = logic.BuyService;
            IService<ICustomer> customersService = logic.CustomersService;
            IInventoryService inventoryService = logic.InventoryService;
            IService<ISupplier> suppliersService = logic.SuppliersService;

            // Make shopping list
            IBook book1 = DataGenerator.newBook();
            int bookId1 = catalogue.add(book1);

            IBook book2 = DataGenerator.newBook();
            int bookId2 = catalogue.add(book2);

            Counter<int> books = new Counter<int>();
            books.Add(bookId1);
            books.Add(bookId2);
            books.Add(bookId2);

            // Make customer
            ICustomer customer = DataGenerator.newCustomer();
            int customerId = customersService.add(customer);

            // Make inventory
            ISupplier supplier = DataGenerator.newSupplier();
            int supplierId = suppliersService.add(supplier);
            inventoryService.supply(bookId1, supplierId, 100);
            inventoryService.supply(bookId2, supplierId, 100);

            // Test NotEnoughItemsInInventory
            Assert.ThrowsException<NotEnoughItemsInInventory>(() =>
            {
                buyService.buy(customerId, books);
            });

            // Supply 
            inventoryService.supply(bookId2, supplierId, 100);
            int invoiceId = buyService.buy(customerId, books);

            // Check invoice
            IInvoice invoice = logic.InvoicesService.get(invoiceId);

            double price = buyService.checkPrice(books);
            Assert.AreEqual(price, invoice.Price);
        }

    }
}
