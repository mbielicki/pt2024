namespace Bookshop.Data.Model
{
    public abstract class ID
    {
        int Value { get; set; }
        public ID(int value) {
            this.Value = value;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            ID other = (ID)obj;
            return other.Value == Value;
        }
    }

    public class BookID : ID
    {
        public BookID(int value) : base(value)
        {
        }
    }
    public class CustomerID : ID
    {
        public CustomerID(int value) : base(value)
        {
        }
    }
    public class InvoiceID : ID
    {
        public InvoiceID(int value) : base(value)
        {
        }
    }
}
