using Data.API;
using Data.Model.Entities;

namespace Data.Database
{
    public class DatabaseDataLayer : IDataLayer
    {
        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupply> Supply { get; }


        public DatabaseDataLayer(string connectionString)
        {
            Catalogue = new CatalogueAPI(connectionString);
            Customers = new CustomersAPI(connectionString);
            Suppliers = new SuppliersAPI(connectionString);
            Invoices = new InvoicesAPI(connectionString);
            Supply = new SupplyAPI(connectionString);
            Inventory = new InventoryAPI(connectionString);
        }
    }
}

