using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class InventoryAPI : IInventoryAPI
    {
        Counter<ID> _document = new Counter<ID> ();
        public InventoryAPI(Counter<ID> document)
        {
            _document = document;
        }

        public void add(ID item)
        {
            _document.add(item);
        }

        public int count(ID item)
        {
            return _document.get(i => i == item);
        }

        public bool remove(ID item, int numberToBuy)
        {
            int count = _document.get(i => i == item);
            if (numberToBuy > count) return false;

            int newCount = count - numberToBuy;
            _document.set(item, numberToBuy);
            return true;
        }

        public bool removeOne(ID id)
        {
            try
            {
                _document.removeOne(id);
            } 
            catch (KeyNotFoundException)
            { 
                return false;
            }
            return true;
        }
    }
}
