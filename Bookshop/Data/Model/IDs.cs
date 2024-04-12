namespace Bookshop.Data.Model
{
    public interface HasId
    {
        ID? Id { get; set; }
    }

    public class ID
    {
        protected int _value { get; set; }
        public ID(int value) {
            _value = value;
        }
        public ID()
        {
            _value = 0;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            ID other = (ID)obj;
            return other._value == _value;
        }
        public ID increment() { 
            _value ++;
            return this;
        }
    }
}
