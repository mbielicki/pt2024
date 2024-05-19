using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic
{
    public interface IService<T>
    {
        int add(T item);
        void remove(int id);
        T get(int id);
        void update(T newItem);
        List<int> getIds();
    }

    public interface IInventoryService
    {
        int count(int bookId);
        void supply(int bookId, int supplierId, double price);
        void supply(Counter<int> bookIds, int supplierId, double price);
        IEnumerable<IInventoryEntry> getAll();
    }

    public interface IEventService<T>
    {
        T get(int id);
        List<int> getIds();
    }

    public interface IBuyService
    {
        int buy(int customerId, Counter<int> books);
        double checkPrice(Counter<int> books);
    }
}
