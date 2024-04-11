namespace Bookshop.Data
{
    public interface IStorage
    {
        void addToCatalogue(Book book);
        void removeFromCatalogue(int bookId);
        Book? getFromCatalogue(int bookId);
    }
}
