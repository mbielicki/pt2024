using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;

namespace Bookshop.Model.Data.InMemoryStorage
{
    internal class InventoryAPI : IInventoryAPI
    {
        Counter<ID> _document = new Counter<ID>();
        public InventoryAPI(Counter<ID> document)
        {
            _document = document;
        }

        public void addOne(ID item)
        {
            _document.Add(item);
        }
        public void add(ID item, int numberToSupply)
        {
            int count = _document.Get(i => i.Equals(item));

            int newCount = count + numberToSupply;
            _document.Set(item, newCount);
        }

        public int count(ID item)
        {
            return _document.Get(i => i.Equals(item));
        }

        public bool remove(ID item, int numberToBuy)
        {
            int count = _document.Get(i => i.Equals(item));
            if (numberToBuy > count) return false;

            int newCount = count - numberToBuy;
            _document.Set(item, newCount);
            return true;
        }

        public bool removeOne(ID id)
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
    }
}
