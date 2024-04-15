using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    public class FileSystemBookshopStorage : IBookshopStorage
    {
        static string folderPath = "Generated Files\\BookshopFileSystemStorage\\";
        string catalogue = folderPath + "catalogue.xml";
        string customers = folderPath + "customers.xml";
        string suppliers = folderPath + "suppliers.xml";
        string invoices = folderPath + "invoices.xml";
        string supplyRegister = folderPath + "supplyRegister.xml";
        string inventory = folderPath + "inventory.xml";

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

