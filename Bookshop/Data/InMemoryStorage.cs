using Bookshop.Data.Model;
using System.Net;

namespace Bookshop.Data
{
    public class InMemoryStorage : IStorage
    {
        Inventory inventory = new Inventory();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Invoice> invoices = new List<Invoice>();
        int nextBookId = 0;

        public void update(Book book)
        {
            Book bookToUpdate = catalogue.Find(b => b.Id == book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }

        public int add(Book book)
        {
            int bookId = nextBookId++;
            book.Id = bookId;
            catalogue.Add(book);
            return bookId;
        }

        public Book? get(Predicate<Book> query)
        {
            return catalogue.Find(query);
        }

        public bool remove(int bookId)
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
