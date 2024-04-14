using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IInventoryAPI
    {
        void addOne(ID item);
        void add(ID item, int numberToSupply);
        bool removeOne(ID item);
        bool remove(ID id, int numberToBuy);
        int count(ID item);
    }
}
