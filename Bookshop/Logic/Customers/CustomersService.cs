using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic.Customers
{
    public class CustomersService : IService<ICustomer>
    {
        private IBookshopStorage _storage;
        private CustomerValidator _validator;
        public CustomersService(IBookshopStorage storage)
        {
            _storage = storage;
            _validator = new CustomerValidator(storage);
        }

        public int add(ICustomer customer)
        {
            if (_validator.incorrectProperties(customer))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(customer))
                throw new ItemAlreadyExists();

            return _storage.Customers.add(customer);
        }

        public ICustomer get(int customerId)
        {
            ICustomer? result = _storage.Customers.get(c => c.Id.Equals(customerId));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds() 
        {
            return _storage.Customers.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int customerId)
        {
            if (_storage.Customers.remove(customerId)) return;
            throw new ItemIdNotFound();
        }

        public void update(ICustomer newCustomer)
        {
            if (_validator.incorrectProperties(newCustomer))
                throw new InvalidItemProperties();
            try
            {
                _storage.Customers.update(newCustomer);
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
