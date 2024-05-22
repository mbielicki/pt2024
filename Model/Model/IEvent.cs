namespace Data.Model
{
    public interface IEvent : IHasId
    {
        DateTime DateTime { get; set; }
    }
}
