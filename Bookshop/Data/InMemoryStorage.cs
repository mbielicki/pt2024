namespace Bookshop.Data
{
    public class InMemoryStorage : IStorage
    {
        Inventory inventory = new Inventory();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Invoice> invoices = new List<Invoice>();


        void IStorage.addToCatalogue(Book book)
        {
            catalogue.Add(book);
        }

        Book? IStorage.getFromCatalogue(int bookId)
        {
            return catalogue.Find(book => book.Id == bookId);
        }

        void IStorage.removeFromCatalogue(int bookId)
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
