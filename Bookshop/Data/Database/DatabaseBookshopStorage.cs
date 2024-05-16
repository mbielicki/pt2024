using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    public class DatabaseBookshopStorage : IBookshopStorage
    {
        Counter<int> inventory = new Counter<int>();
        List<ISupplyRegisterEntry> supplyRegister = new List<ISupplyRegisterEntry>();

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupplyRegisterEntry> SupplyRegister { get; }


        public DatabaseBookshopStorage()
        {
            Catalogue = new CatalogueAPI();
            Customers = new CustomersAPI();
            Suppliers = new SuppliersAPI();
            Invoices = new InvoicesAPI();
            SupplyRegister = new SupplyRegisterAPI(supplyRegister);
            Inventory = new InventoryAPI(inventory);
        }
    }
}

