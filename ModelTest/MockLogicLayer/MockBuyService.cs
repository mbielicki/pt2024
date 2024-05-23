using Logic;
using Logic.Model;

namespace ModelTest.MockLogicLayer
{
    internal class MockBuyService : IBuyService
    {
        public int buy(int customerId, Counter<int> books)
        {
            throw new NotImplementedException();
        }

        public double checkPrice(Counter<int> books)
        {
            return 0;
        }
    }
}