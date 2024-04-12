using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface IStorage<T>
    {
        ID add(T item);
        bool remove(ID id);
        T? get(Predicate<T> query);
        void update(T newItem);
    }
}
