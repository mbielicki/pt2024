namespace Model.Model.Entities
{
    public interface ISupply : IEvent
    {
        ISupplier Supplier { get; set; }
        double Price { get; set; }
        Counter<IBook> Books { get; set; }
    }


    public class SimpleSupply : ISupply
    {
        public int? Id { get; set; }
        public ISupplier Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
        public SimpleSupply(int? id, Counter<IBook> books, ISupplier supplier, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Supplier = supplier;
            Price = price;
            DateTime = dateTime;
        }

        public SimpleSupply()
        {
        }
    }
}
