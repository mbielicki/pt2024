using Bookshop.Data.Model;

namespace Bookshop.Data
{
    public interface IStorage
    {
        void add(Book book);
        void remove(int bookId);
        Book get(int bookId);
        void update(Book book);
    }
}
