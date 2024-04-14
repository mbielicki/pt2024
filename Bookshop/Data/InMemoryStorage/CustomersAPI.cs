using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class CustomersAPI : IInMemoryStorage<Customer>
    {
        public CustomersAPI(List<Customer> document) : base(document)
        {
        }
        public override void update(Customer newCustomer)
        {
            Customer customerToUpdate = _document.Find(c => c.Id.Equals(newCustomer.Id));
            customerToUpdate.FirstName = newCustomer.FirstName;
            customerToUpdate.LastName = newCustomer.LastName;
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.ContactInfo = newCustomer.ContactInfo;
        }

    }
}
