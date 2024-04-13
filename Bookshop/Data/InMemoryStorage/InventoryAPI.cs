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

        public bool remove(ID id)
        {
            try
            {
                _document.remove(id);
            } 
            catch (KeyNotFoundException)
            { 
                return false;
            }
            return true;
        }
    }
}
