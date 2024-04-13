namespace Bookshop.Data.Model
{
    public interface HasId
    {
        ID? Id { get; set; }
    }

    public class ID
    {
        public int Value { get; private set; }
        public ID(int value) {
            Value = value;
        }
        public ID()
        {
            Value = 0;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            ID other = (ID)obj;
            return other.Value == Value;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public ID increment() { 
            Value ++;
            return this;
        }
    }
}
