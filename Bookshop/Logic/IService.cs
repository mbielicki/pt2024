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
}
