using Bookshop.Data.Model.Entities;

namespace BookshopTest.Data.InMemoryMockDataLayer
{
    internal class CustomersAPI : IInMemoryStorage<ICustomer>
    {
        public CustomersAPI(List<ICustomer> document) : base(document)
        {
        }
        public override void update(ICustomer newCustomer)
        {
            ICustomer customerToUpdate = _document.Find(c => c.Id.Equals(newCustomer.Id));
            customerToUpdate.FirstName = newCustomer.FirstName;
            customerToUpdate.LastName = newCustomer.LastName;
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.ContactInfo = newCustomer.ContactInfo;
        }

    }
}
