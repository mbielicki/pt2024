namespace Bookshop.Data.Model.Entities
{
    public interface IInvoice : IEvent
    {
        ICustomer Customer { get; set; }
        double Price { get; set; }
        Counter<IBook> Books { get; set; }
    }

    public class SimpleInvoice : IInvoice
    {
        public int? Id { get; set; }
        public ICustomer Customer { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
        public SimpleInvoice(int? id, Counter<IBook> books, ICustomer customer, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Customer = customer;
            Price = price;
            DateTime = dateTime;
        }
    }
}
