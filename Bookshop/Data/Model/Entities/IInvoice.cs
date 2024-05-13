using Bookshop.Data.Model;

namespace Bookshop.Data.Model.Entities
{
    public interface IInvoice : IEvent
    {
        ID Id { get; set; }
        ICustomer Customer { get; set; }
        double Price { get; set; }
        DateTime DateTime { get; set; }
        Counter<IBook> Books { get; set; }
    }

    public class iInvoice : IInvoice
    {
        public ID Id { get; set; }
        public ICustomer Customer { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
        public iInvoice(ID id, Counter<IBook> books, ICustomer customer, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Customer = customer;
            Price = price;
            DateTime = dateTime;
        }

        public iInvoice() { }
    }
}
