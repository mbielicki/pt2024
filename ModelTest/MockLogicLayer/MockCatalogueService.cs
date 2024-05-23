using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    public class MockCatalogueService : IService<IBook>
    {
        public int add(IBook item)
        {
            throw new NotImplementedException();
        }

        public IBook get(int id)
        {
            return new SimpleBook();
        }

        public List<int> getIds()
        {
            return new List<int>();
        }

        public void remove(int id)
        {
            throw new NotImplementedException();
        }

        public void update(IBook newItem)
        {
            throw new NotImplementedException();
        }
    }
}