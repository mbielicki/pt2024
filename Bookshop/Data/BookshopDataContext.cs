namespace Bookshop.Data
{
    public class BookshopDataContext
    {
        public Inventory Inventory { get; private set; } = new Inventory();
        public HashSet<Book> Catalogue { get; private set; } = new HashSet<Book>();
        public List<Customer> Customers { get; private set; } = new List<Customer>();
        public List<Invoice> Invoices { get; private set; } = new List<Invoice>();

    }
}
