using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.InMemoryStorage
{
    public class InMemoryBookshopStorage : IBookshopStorage
    {
        Counter<ID> inventory = new Counter<ID>();
        List<IBook> catalogue = new List<IBook>();
        List<ICustomer> customers = new List<ICustomer>();
        List<ISupplier> suppliers = new List<ISupplier>();
        List<IInvoice> invoices = new List<IInvoice>();
        List<ISupplyRegisterEntry> supplyRegister = new List<ISupplyRegisterEntry>();

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupplyRegisterEntry> SupplyRegister { get; }


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

