using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    internal class MockSupplyService : IEventService<ISupply>
    {
        public ISupply get(int id)
        {
            return new SimpleSupply();
        }

        public List<int> getIds()
        {
            return new List<int>();
        }
    }
}