using Bookshop.Data.Model;

namespace Bookshop.Data
{
    public interface IStorage
    {
        int add(Book book);
        bool remove(int bookId);
        Book? get(Predicate<Book> query);
        void update(Book book);
    }
}
