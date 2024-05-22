namespace Logic.Model
{
    public interface IEvent : IHasId
    {
        DateTime DateTime { get; set; }
    }
}
