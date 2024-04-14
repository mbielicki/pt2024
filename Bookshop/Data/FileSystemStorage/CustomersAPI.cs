using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class CustomersAPI : IFileSystemStorage<Customer>
    {
        public CustomersAPI(string document) : base(document)
        {
        }
        public override void update(Customer newCustomer)
        {
            Customer customerToUpdate = new Customer(null, null, null, null, null); //_document.Find(c => c.Id == newCustomer.Id);
            customerToUpdate.FirstName = newCustomer.FirstName;
            customerToUpdate.LastName = newCustomer.LastName;
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.ContactInfo = newCustomer.ContactInfo;
        }

    }
}
