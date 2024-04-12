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


        public StorageAPI<BookID, Book> Catalogue { get; }

        public InMemoryStorage() 
        {
            Catalogue = new CatalogueAPI(catalogue);
        }


    }
    class CatalogueAPI : StorageAPI<BookID, Book>
    {
        List<Book> document;
        BookID nextBookId = new BookID(0);

        public CatalogueAPI(List<Book> catalogue)
        {
            this.document = catalogue;
        }

        public void update(Book book)
        {
            Book bookToUpdate = document.Find(b => b.Id == book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }

        public BookID add(Book book)
        {
            BookID bookId = nextBookId++;
            book.Id = bookId;
            document.Add(book);
            return bookId;
        }

        public Book? get(Predicate<Book> query)
        {
            return document.Find(query);
        }

        public bool remove(BookID bookId)
        {
            foreach (Book book in document)
            {
                if (book.Id == bookId)
                {
                    document.Remove(book);
                    return true;
                }
            }
            return false;
        }
    }

}

