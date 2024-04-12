namespace Bookshop.Data.Model
{
    public class Invoice
    {
        public int Id { get; private set; }
        public List<Book> Books { get; private set; }
        public Customer Customer { get; private set; }
        public double Price { get; private set; }
        public DateTime DateTime { get; private set; }
        public Invoice(int id, List<Book> books, Customer customer, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Customer = customer;
            Price = price;
            DateTime = dateTime;
        }
    }
}
