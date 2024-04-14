using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    public class FileSystemBookshopStorage : IBookshopStorage
    {
        //string inventory = "data/inventory.xml";
        Counter<ID> inventory = new Counter<ID>();
        string catalogue = "data/catalogue.xml";
        string customers = "data/customers.xml";
        string suppliers = "data/suppliers.xml";
        string invoices = "data/invoices.xml";
        string supplyRegister = "data/supplyRegister.xml";

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<Book> Catalogue { get; }
        public IStorageAPI<Customer> Customers { get; }
        public IStorageAPI<Supplier> Suppliers { get; }
        public IStorageAPI<Invoice> Invoices { get; }
        public IStorageAPI<SupplyRegisterEntry> SupplyRegister { get; }


        public FileSystemBookshopStorage()
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

