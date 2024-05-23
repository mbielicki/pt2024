using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    internal class MockSuppliersService : IService<ISupplier>
    {
        public int add(ISupplier item)
        {
            throw new NotImplementedException();
        }

        public ISupplier get(int id)
        {
            return new SimpleSupplier();
        }

        public List<int> getIds()
        {
            return new List<int>();
        }

        public void remove(int id)
        {
            throw new NotImplementedException();
        }

        public void update(ISupplier newItem)
        {
            throw new NotImplementedException();
        }
    }
}