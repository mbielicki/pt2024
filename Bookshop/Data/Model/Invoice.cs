namespace Bookshop.Data.Model
{
    public class Invoice : HasId
    {
        public ID? Id { get; set; }
        public List<Book> Books { get; private set; }
        public Customer Customer { get; private set; }
        public double Price { get; private set; }
        public DateTime DateTime { get; private set; }
        public Invoice(ID id, List<Book> books, Customer customer, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Customer = customer;
            Price = price;
            DateTime = dateTime;
        }
    }
}
