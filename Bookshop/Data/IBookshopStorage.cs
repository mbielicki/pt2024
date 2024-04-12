using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data
{
    public interface IBookshopStorage
    {
        StorageAPI<BookID, Book> Catalogue { get; }
    }
}
