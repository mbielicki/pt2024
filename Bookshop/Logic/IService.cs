using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    public interface IService<T>
    {
        ID add(T item);
        void remove(ID id);
        T get(ID id);
        void update(T newItem);
        List<ID> getIds();
    }
}
