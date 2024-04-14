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
        List<SupplyRegisterEntry> supplyRegister = new List<SupplyRegisterEntry>();

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<Book> Catalogue { get; }
        public IStorageAPI<Customer> Customers { get; }
        public IStorageAPI<Supplier> Suppliers { get; }
        public IStorageAPI<Invoice> Invoices { get; }
        public IStorageAPI<SupplyRegisterEntry> SupplyRegister { get; }


        public InMemoryBookshopStorage()
        {
            Catalogue = new CatalogueAPI(catalogue);
            Customers = new CustomersAPI(customers);
            Suppliers = new SuppliersAPI(suppliers);
            Invoices = new InvoicesAPI(invoices);
            SupplyRegister = new SupplyRegisterAPI(supplyRegister);
            Inventory = new InventoryAPI(inventory);
        }
    }
}

