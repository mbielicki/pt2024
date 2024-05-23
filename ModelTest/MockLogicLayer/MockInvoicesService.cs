using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    internal class MockInvoicesService : IEventService<IInvoice>
    {
        public IInvoice get(int id)
        {
            return new SimpleInvoice();
        }

        public List<int> getIds()
        {
            return new List<int>();
        }
    }
}