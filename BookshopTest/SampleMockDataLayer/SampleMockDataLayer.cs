using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace BookshopTest.Data.SampleMockDataLayer
{
    public class SampleMockDataLayer : IDataLayer
    {
        Counter<int> inventory = new Counter<int>();
        List<IBook> catalogue = new List<IBook>();
        List<ICustomer> customers = new List<ICustomer>();
        List<ISupplier> suppliers = new List<ISupplier>();
        List<IInvoice> invoices = new List<IInvoice>();
        List<ISupply> supplyRegister = new List<ISupply>();

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupply> Supply { get; }


        public SampleMockDataLayer()
        {
            Catalogue = new CatalogueAPI(catalogue);
            Customers = new CustomersAPI(customers);
            Suppliers = new SuppliersAPI(suppliers);
            Invoices = new InvoicesAPI(invoices);
            Supply = new SupplyAPI(supplyRegister);
            Inventory = new InventoryAPI(inventory);

            AddSampleMockData();
        }

        private void AddSampleMockData()
        {
            IBook newBook = DataGenerator.newBook();
            int bookId = Catalogue.add(newBook);

            ICustomer newCustomer = DataGenerator.newCustomer();
            Customers.add(newCustomer);

            ISupplier newSupplier = DataGenerator.newSupplier();
            Suppliers.add(newSupplier);

            Inventory.add(bookId, 10);

            Counter<IBook> books = new Counter<IBook>();
            books.Set(newBook, 2);

            Supply.add(new SimpleSupply()
            {
                Id = 0,
                Books = books,
                Supplier = newSupplier,
                Price = 50,
                DateTime = DateTime.Now
            });

            Inventory.add(bookId, 2);

            Invoices.add(new SimpleInvoice()
            {
                Id = 0,
                Books = books,
                Customer = newCustomer,
                Price = 100,
                DateTime = DateTime.Now
            });

            Inventory.remove(bookId, 2);

        }
    }
}

