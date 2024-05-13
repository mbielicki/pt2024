using Bookshop.Data.Model;

namespace Bookshop.Data.Model.Entities
{
    public interface ISupplyRegisterEntry : IEvent
    {
        ID Id { get; set; }
        ISupplier Supplier { get; set; }
        double Price { get; set; }
        DateTime DateTime { get; set; }
        Counter<IBook> Books { get; set; }
    }


    public class iSupplyRegisterEntry : ISupplyRegisterEntry
    {
        public ID Id { get; set; }
        public ISupplier Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<IBook> Books { get; set; }
        public iSupplyRegisterEntry(ID id, Counter<IBook> books, ISupplier supplier, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Supplier = supplier;
            Price = price;
            DateTime = dateTime;
        }
        public iSupplyRegisterEntry() { }
    }
}
