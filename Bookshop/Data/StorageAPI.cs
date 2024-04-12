using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface StorageAPI<T>
    {
        ID add(T item);
        void remove(ID id);
        T? get(Predicate<T> query);
        void update(T item);
    }
}
