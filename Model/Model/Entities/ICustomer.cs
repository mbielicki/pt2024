namespace Data.Model.Entities
{
    public interface ICustomer : IPerson
    {
    }

    public class SimpleCustomer : ICustomer
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string ContactInfo { get; set; }

        public SimpleCustomer(int? id, string firstName, string lastName, string address, string contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ContactInfo = contactInfo;
        }

        public SimpleCustomer()
        {
        }
    }
}
