using Bookshop.Data.Model;

namespace Bookshop.Data
{
    public interface IBookshopStorage
    {
        BookID add(Book book);
        bool remove(BookID bookId);
        Book? get(Predicate<Book> query);
        void update(Book book);
    }
}
