using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    public class DatabaseBookshopStorage : IBookshopStorage
    {
        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupply> Supply { get; }


        public DatabaseBookshopStorage()
        {
            Catalogue = new CatalogueAPI();
            Customers = new CustomersAPI();
            Suppliers = new SuppliersAPI();
            Invoices = new InvoicesAPI();
            Supply = new SupplyAPI();
            Inventory = new InventoryAPI();
        }
    }
}

