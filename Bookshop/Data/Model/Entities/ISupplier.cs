using Bookshop.Data.Model;

namespace Bookshop.Data.Model.Entities
{
    public interface ISupplier : IPerson
    {
        ID Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string CompanyName { get; set; }
        string Address { get; set; }
        string ContactInfo { get; set; }
    }

    public class Supplier : ISupplier
    {
        public ID Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public Supplier(ID id, string firstName, string lastName, string companyName, string address, string contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Address = address;
            ContactInfo = contactInfo;
        }
        public Supplier() { }
    }
}
