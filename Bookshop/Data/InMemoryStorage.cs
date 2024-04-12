using Bookshop.Data.API;
using Bookshop.Data.Model;
namespace Bookshop.Data
{
    public class InMemoryStorage : IBookshopStorage
    {
        Counter<BookID> inventory = new Counter<BookID>();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Invoice> invoices = new List<Invoice>();
        BookID nextBookId = new BookID(0);

        //public StorageAPI Catalogue = StorageAPIFactory(catalogue);

        //public interface StorageAPI
        //{
        //    int add()
        //}
        //public class StorageAPI
        //{
        //    private Document do

        //    public void update(Book book)
        //    {
        //        Book bookToUpdate = document.Find(b => b.Id == book.Id);
        //        bookToUpdate.Name = book.Name;
        //        bookToUpdate.Author = book.Author;
        //        bookToUpdate.Description = book.Description;
        //        bookToUpdate.Price = book.Price;
        //    }
        //}

        public void update(Book book)
        {
            Book bookToUpdate = catalogue.Find(b => b.Id == book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }

        public BookID add(Book book)
        {
            BookID bookId = nextBookId++;
            book.Id = bookId;
            catalogue.Add(book);
            return bookId;
        }

        public Book? get(Predicate<Book> query)
        {
            return catalogue.Find(query);
        }

        public bool remove(BookID bookId)
        {
            foreach (Book book in catalogue)
            {
                if (book.Id == bookId)
                {
                    catalogue.Remove(book);
                    return true;
                }
            }
            return false;
        }

    }
}
