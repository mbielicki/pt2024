using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IInventoryAPI
    {
        void add(ID item);
        bool remove(ID item);
        int count(ID item);
    }
}
