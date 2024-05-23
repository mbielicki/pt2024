using Logic;
using Logic.Model;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    internal class MockInventoryService : IInventoryService
    {
        public int count(int bookId)
        {
            return 0;
        }

        public IEnumerable<IInventoryEntry> getAll()
        {
            return new List<IInventoryEntry>();
        }

        public void supply(int bookId, int supplierId, double price)
        {
            throw new NotImplementedException();
        }

        public void supply(Counter<int> bookIds, int supplierId, double price)
        {
            throw new NotImplementedException();
        }
    }
}