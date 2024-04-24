using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IBookshopStorage
    {
        IStorageAPI<IBook> Catalogue { get; }
        IStorageAPI<ICustomer> Customers { get; }
        IStorageAPI<ISupplier> Suppliers { get; }
        IStorageAPI<IInvoice> Invoices { get; }
        IStorageAPI<ISupplyRegisterEntry> SupplyRegister { get; }
        IInventoryAPI Inventory {  get; }
    }
}
