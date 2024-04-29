using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;

namespace Bookshop.Model.Data.InMemoryStorage
{
    internal abstract class IInMemoryStorage<T> : IStorageAPI<T> where T : HasId
    {
        protected List<T> _document;
        int nextId = 0;

        public IInMemoryStorage(List<T> document)
        {
            _document = document;
        }

        public ID add(T item)
        {
            ID id = new ID(nextId++);
            item.Id = id;
            _document.Add(item);
            return id;
        }

        public T? get(Predicate<T> query)
        {
            return _document.Find(query);
        }

        public List<T> getAll(Predicate<T> query)
        {
            return _document.FindAll(query);
        }

        public bool remove(ID id)
        {
            foreach (T item in _document)
            {
                if (item.Id.Equals(id))
                {
                    _document.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public abstract void update(T newItem);
    }
}
