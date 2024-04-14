using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal abstract class IFileSystemStorage<T> : IStorageAPI<T> where T : HasId
    {
        int nextId = 0;
        List<T> _document = new List<T>();
        string filePath;

        public IFileSystemStorage(string filePath)
        {
            this.filePath = filePath;
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
                if (item.Id == id)
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
