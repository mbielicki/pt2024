using Bookshop.Data.Model;
using System.Net;

namespace Bookshop.Data.FileSystemStorage
{
    internal class CustomersAPI : IFileSystemStorage<Customer>
    {
        public CustomersAPI(string document) : base(document)
        {
        }
        public override void update(Customer newCustomer)
        {
            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);

            Customer customerToUpdate = get(c => c.Id.Equals(newCustomer.Id));
            customerToUpdate.FirstName = newCustomer.FirstName;
            customerToUpdate.LastName = newCustomer.LastName;
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.ContactInfo = newCustomer.ContactInfo;

            Serialization.WriteToXmlFile(filePath, _document);
        }

    }
}
