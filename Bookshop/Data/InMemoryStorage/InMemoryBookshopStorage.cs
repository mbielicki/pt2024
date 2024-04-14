using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    public class InMemoryBookshopStorage : IBookshopStorage
    {
        Counter<ID> inventory = new Counter<ID>();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Invoice> invoices = new List<Invoice>();


        public IStorageAPI<Book> Catalogue { get; }
        public IStorageAPI<Customer> Customers { get; }
        public IStorageAPI<Invoice> Invoices { get; }
        public IStorageAPI<Supplier> Suppliers { get; }

        public IInventoryAPI Inventory {  get; }

        public InMemoryBookshopStorage()
        {
            Catalogue = new CatalogueAPI(catalogue);
            Customers = new CustomersAPI(customers);
            Suppliers = new SuppliersAPI(suppliers);
            Invoices = new InvoicesAPI(invoices);
            Inventory = new InventoryAPI(inventory);
        }
    }
}

