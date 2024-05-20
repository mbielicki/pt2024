using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace BookshopTest.DataGeneration.MockDataLayerInMemory
{
    internal class InventoryAPI : IInventoryAPI
    {
        Counter<int> _document = new Counter<int>();
        public InventoryAPI(Counter<int> document)
        {
            _document = document;
        }

        public void addOne(int item)
        {
            _document.Add(item);
        }
        public void add(int item, int numberToSupply)
        {
            int count = _document.Get(i => i.Equals(item));

            int newCount = count + numberToSupply;
            _document.Set(item, newCount);
        }

        public int count(int item)
        {
            return _document.Get(i => i.Equals(item));
        }

        public bool remove(int item, int numberToBuy)
        {
            int count = _document.Get(i => i.Equals(item));
            if (numberToBuy > count) return false;

            int newCount = count - numberToBuy;
            _document.Set(item, newCount);
            return true;
        }

        public bool removeOne(int id)
        {
            try
            {
                _document.RemoveOne(id);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<int> getIds()
        {
            return _document.Keys;
        }
    }
}
