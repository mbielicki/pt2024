namespace Bookshop.Data.Model
{
    public interface IEvent : IHasId
    {
        DateTime DateTime { get; set; }
    }
}
