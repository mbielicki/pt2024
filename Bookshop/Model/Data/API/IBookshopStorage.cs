using Bookshop.Model.Data.Model.Entities;

namespace Bookshop.Model.Data.API
{
    public interface IBookshopStorage
    {
        IStorageAPI<IBook> Catalogue { get; }
        IStorageAPI<ICustomer> Customers { get; }
        IStorageAPI<ISupplier> Suppliers { get; }
        IStorageAPI<IInvoice> Invoices { get; }
        IStorageAPI<ISupplyRegisterEntry> SupplyRegister { get; }
        IInventoryAPI Inventory { get; }
    }
}
