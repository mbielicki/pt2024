namespace Bookshop.Data.Model
{
    public interface ISupplyRegisterEntry : IEvent
    {
        public ID? Id { get; set; }
        public ISupplier Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
    }


    public class SupplyRegisterEntry : ISupplyRegisterEntry
    {
        public ID? Id { get; set; }
        public ISupplier Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
        public SupplyRegisterEntry(ID? id, Counter<IBook> books, ISupplier supplier, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Supplier = supplier;
            Price = price;
            DateTime = dateTime;
        }
        public SupplyRegisterEntry() { }
    }
}
