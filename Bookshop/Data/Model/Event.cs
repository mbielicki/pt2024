namespace Bookshop.Data.Model
{
    public interface Event : HasId
    {
        DateTime DateTime { get; set; }
    }
}
