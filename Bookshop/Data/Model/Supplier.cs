namespace Bookshop.Data.Model
{
    public class Supplier : Person
    {
        public ID? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? ContactInfo { get; set; }

        public Supplier(ID? id, string? firstName, string? lastName, string? companyName, string? address, string? contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Address = address;
            ContactInfo = contactInfo;
            CompanyName = companyName;
        }
    }
}
