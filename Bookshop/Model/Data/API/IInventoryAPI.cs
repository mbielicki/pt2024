using Bookshop.Model.Data.Model;

namespace Bookshop.Model.Data.API
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
