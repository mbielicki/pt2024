namespace Model.Model
{
    public interface IEvent : IHasId
    {
        DateTime DateTime { get; set; }
    }
}
