namespace Bookshop.Data.Model
{
    public interface IEvent : HasId
    {
        DateTime DateTime { get; set; }
    }
}
