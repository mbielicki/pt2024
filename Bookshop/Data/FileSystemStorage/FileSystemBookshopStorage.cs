using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage.Documents;
using Bookshop.Data.Model.Entities;

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
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupplyRegisterEntry> SupplyRegister { get; }


        public FileSystemBookshopStorage()
        {
            CatalogueAPI catalogueTemp = new CatalogueAPI(catalogue);
            CustomersAPI customersTemp = new CustomersAPI(customers);
            SuppliersAPI suppliersTemp = new SuppliersAPI(suppliers);
            Catalogue = catalogueTemp;
            Customers = customersTemp;
            Suppliers = suppliersTemp;
            Invoices = new InvoicesAPI(invoices, catalogueTemp, customersTemp);
            SupplyRegister = new SupplyRegisterAPI(supplyRegister, catalogueTemp, suppliersTemp);
            Inventory = new InventoryAPI(inventory);
        }
    }
}

