namespace Bookshop.Data.Model
{
    public class Invoice : HasId
    {
        public ID? Id { get; set; }
        public Counter<ID>? Books { get; set; }
        public ID? Customer { get; set; }
        public double? Price { get; set; }
        public DateTime? DateTime { get; set; }
        public Invoice(ID? id, Counter<ID>? books, ID? customer, double? price, DateTime? dateTime)
        {
            Id = id;
            Books = books;
            Customer = customer;
            Price = price;
            DateTime = dateTime;
        }
        public Invoice() { }
    }
}
