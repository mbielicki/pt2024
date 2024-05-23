using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    internal class MockCustomersService : IService<ICustomer>
    {
        public int add(ICustomer item)
        {
            throw new NotImplementedException();
        }

        public ICustomer get(int id)
        {
            return new SimpleCustomer();
        }

        public List<int> getIds()
        {
            return new List<int>();
        }

        public void remove(int id)
        {
            throw new NotImplementedException();
        }

        public void update(ICustomer newItem)
        {
            throw new NotImplementedException();
        }
    }
}