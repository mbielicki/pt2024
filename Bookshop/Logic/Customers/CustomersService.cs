using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic.Customers
{
    public class CustomersService : IService<Customer>
    {
        private IBookshopStorage _storage;
        private CustomerValidator _validator;
        public CustomersService(IBookshopStorage storage)
        {
            _storage = storage;
            _validator = new CustomerValidator(storage);
        }

        public ID add(Customer customer)
        {
            if (_validator.incorrectProperties(customer))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(customer))
                throw new ItemAlreadyExists();

            return _storage.Customers.add(customer);
        }

        public Customer get(ID customerId)
        {
            Customer? result = _storage.Customers.get(c => c.Id == customerId);
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public void remove(ID customerId)
        {
            if (_storage.Customers.remove(customerId)) return;
            throw new ItemIdNotFound();
        }

        public void update(Customer newCustomer)
        {
            if (_validator.incorrectProperties(newCustomer))
                throw new InvalidItemProperties();
            Customer? result = _storage.Customers.get(b => b.Id == newCustomer.Id);
            if (result == null)
                throw new ItemIdNotFound();

            result.FirstName = newCustomer.FirstName;
            result.LastName = newCustomer.LastName;
            result.Address = newCustomer.Address;
            result.ContactInfo = newCustomer.ContactInfo;

        }
    }
}
