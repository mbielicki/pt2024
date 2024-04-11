namespace Bookshop.Data
{
    public class Customer
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Address { get; private set; }

        public string? ContactInfo { get; private set; }

        public Customer(int id, string firstName, string lastName, string? address, string? contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ContactInfo = contactInfo;
        }
    }
}
