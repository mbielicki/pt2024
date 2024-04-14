using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IBookshopStorage
    {
        IStorageAPI<Book> Catalogue { get; }
        IStorageAPI<Customer> Customers { get; }
        IStorageAPI<Supplier> Suppliers { get; }
        IStorageAPI<Invoice> Invoices { get; }
        IStorageAPI<SupplyRegisterEntry> SupplyRegister { get; }
        IInventoryAPI Inventory {  get; }
    }
}
