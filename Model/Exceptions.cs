namespace Presentation.Model
{
    public class ItemAlreadyExists : Exception { }
    public class InvalidItemProperties : Exception { }
    public class ItemIdNotFound : Exception { }
    public class EmptyBookCounterException : Exception { }
    public class CustomerIdNotFound : ItemIdNotFound { }
    public class BookIdNotFound : ItemIdNotFound { }
    public class NotEnoughItemsInInventory : Exception
    {
        public NotEnoughItemsInInventory(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
    public class BookWithCountZeroInCounterException : Exception
    {
        public BookWithCountZeroInCounterException(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }

}
