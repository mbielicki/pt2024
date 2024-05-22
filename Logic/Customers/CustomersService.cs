using Data.API;
using Logic.Model;

namespace Logic.Customers
{
    public class CustomersService : IService<Model.Entities.ICustomer>
    {
        private IDataLayer _dataLayer;
        private CustomerValidator _validator;
        public CustomersService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new CustomerValidator(dataLayer);
        }

        public int add(Model.Entities.ICustomer customer)
        {
            if (_validator.incorrectProperties(customer.ToData()))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(customer.ToData()))
                throw new ItemAlreadyExists();

            return _dataLayer.Customers.add(customer.ToData());
        }

        public Model.Entities.ICustomer get(int customerId)
        {
            Data.Model.Entities.ICustomer? result = _dataLayer.Customers.get(c => c.Id.Equals(customerId));
            if (result == null)
                throw new CustomerIdNotFound();
            return result.ToLogic();
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

        public void update(Model.Entities.ICustomer newCustomer)
        {
            if (_validator.incorrectProperties(newCustomer.ToData()))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Customers.update(newCustomer.ToData());
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
