using Bookshop.Data.Model;

namespace Bookshop.Data.API
{
    public interface StorageAPI<I, T> where I : ID
    {
        I add(T item);
        bool remove(I id);
        T get(Predicate<T> query);
        void update(T newItem);
    }
}
