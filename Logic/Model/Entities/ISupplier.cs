namespace Logic.Model.Entities
{
    public interface ISupplier : IPerson
    {
        string CompanyName { get; set; }
    }

    public class SimpleSupplier : ISupplier
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public SimpleSupplier(int? id, string firstName, string lastName, string companyName, string address, string contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Address = address;
            ContactInfo = contactInfo;
        }

        public SimpleSupplier()
        {
        }
    }
}
