using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IInventoryAPI
    {
        void add(ID item);
        bool removeOne(ID item);
        bool remove(ID id, int numberToBuy);
        int count(ID item);
    }
}
