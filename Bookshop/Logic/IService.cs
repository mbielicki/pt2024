using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    public interface IService
    {
        int add(Book book);
        void remove(int bookId);
        Book get(int bookId);
        void update(Book newBook);
    }
}
