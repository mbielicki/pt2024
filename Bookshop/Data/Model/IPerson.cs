namespace Bookshop.Data.Model
{
    public interface IPerson : HasId
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string ContactInfo { get; set; }
    }
}
