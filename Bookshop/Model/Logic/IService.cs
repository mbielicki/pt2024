using Bookshop.Model.Data.Model;

namespace Bookshop.Model.Logic
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
