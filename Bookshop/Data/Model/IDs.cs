namespace Bookshop.Data.Model
{
    public abstract class ID
    {
        protected int _value { get; set; }
        public ID(int value) {
            _value = value;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            ID other = (ID)obj;
            return other._value == _value;
        }
        public static ID operator ++(ID id) { 
            id._value ++; 
            return id;
        }
    }

    public class BookID : ID
    {
        public BookID(int value) : base(value)
        {
        }
        public static BookID operator ++(BookID id)
        {
            id._value++;
            return id;
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
