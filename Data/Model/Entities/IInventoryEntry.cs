namespace Data.Model.Entities
{
    public interface IInventoryEntry
    {
        IBook Book { get; set; }
        int Count { get; set;  }

    }

    public class SimpleInventoryEntry : IInventoryEntry
    {
        public IBook Book { get; set; }
        public int Count { get; set; }
    }
}
