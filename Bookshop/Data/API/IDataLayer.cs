using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.API
{
    public interface IDataLayer
    {
        IStorageAPI<IBook> Catalogue { get; }
        IStorageAPI<ICustomer> Customers { get; }
        IStorageAPI<ISupplier> Suppliers { get; }
        IStorageAPI<IInvoice> Invoices { get; }
        IStorageAPI<ISupply> Supply { get; }
        IInventoryAPI Inventory { get; }
    }
}
