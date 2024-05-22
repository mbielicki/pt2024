using Data.API;
using Data.Model;

namespace BookshopTest.DataGeneration.MockDataLayerSample
{
    internal abstract class ISampleStorage<T> : IStorageAPI<T> where T : IHasId
    {
        protected List<T> _document;
        int nextId = 0;

        public ISampleStorage(List<T> document)
        {
            _document = document;
        }

        public int add(T item)
        {
            int id = nextId++;
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

        public bool remove(int id)
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
