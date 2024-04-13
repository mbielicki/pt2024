using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IBookshopStorage
    {
        IStorage<Book> Catalogue { get; }
        IStorage<Customer> Customers { get; }
        IInventoryAPI Inventory {  get; }
    }
}
