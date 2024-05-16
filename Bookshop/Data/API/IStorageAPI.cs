using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IStorageAPI<T>
    {
        int add(T item);
        bool remove(int id);
        T? get(Predicate<T> query);
        void update(T newItem);
        List<T> getAll(Predicate<T> query);
    }
}
