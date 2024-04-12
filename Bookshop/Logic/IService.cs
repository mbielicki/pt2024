using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    public interface IService<I, T> where I : ID
    {
        I add(T item);
        void remove(I id);
        T get(I id);
        void update(T newItem);
    }
}
