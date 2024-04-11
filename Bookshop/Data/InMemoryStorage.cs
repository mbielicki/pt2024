using Bookshop.Data.Model;

namespace Bookshop.Data
{
    public class InMemoryStorage : IStorage
    {
        Inventory inventory = new Inventory();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Invoice> invoices = new List<Invoice>();

        public void update(Book book)
        {
            Book bookToUpdate = catalogue.Find(b => b.Id == book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }

        public void add(Book book)
        {
            catalogue.Add(book);
        }

        public Book get(int bookId)
        {
            return catalogue.Find(book => book.Id == bookId);
        }

        public void remove(int bookId)
        {
            foreach (Book book in catalogue)
            {
                if (book.Id == bookId)
                {
                    catalogue.Remove(book);
                    break;
                }
            }
        }
    }
}
