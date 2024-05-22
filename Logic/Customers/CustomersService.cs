using Data.API;
using Data.Model.Entities;

namespace Logic.Customers
{
    public class CustomersService : IService<ICustomer>
    {
        private IDataLayer _dataLayer;
        private CustomerValidator _validator;
        public CustomersService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new CustomerValidator(dataLayer);
        }

        public int add(ICustomer customer)
        {
            if (_validator.incorrectProperties(customer))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(customer))
                throw new ItemAlreadyExists();

            return _dataLayer.Customers.add(customer);
        }

        public ICustomer get(int customerId)
        {
            ICustomer? result = _dataLayer.Customers.get(c => c.Id.Equals(customerId));
            if (result == null)
                throw new CustomerIdNotFound();
            return result;
        }

        public List<int> getIds() 
        {
            return _dataLayer.Customers.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int customerId)
        {
            if (_dataLayer.Customers.remove(customerId)) return;
            throw new ItemIdNotFound();
        }

        public void update(ICustomer newCustomer)
        {
            if (_validator.incorrectProperties(newCustomer))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Customers.update(newCustomer);
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
