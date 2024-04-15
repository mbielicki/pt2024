using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal abstract class IFileSystemStorage<T> : IStorageAPI<T> where T : HasId
    {
        int nextId;
        protected List<T> _document;
        protected readonly string filePath;

        public IFileSystemStorage(string filePath)
        {
            this.filePath = filePath;
            _document = new List<T>();
            try
            {
                _document = Serialization.ReadFromXmlFile<List<T>>(filePath);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            } catch (Exception) { 
                Serialization.WriteToXmlFile(filePath, _document);
                nextId = 0;
            }
            //Serialization.WriteToXmlFile(filePath, new List<T>()); // clear database on every start
        }

        public ID add(T item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = Serialization.ReadFromXmlFile<List<T>>(filePath);
            _document.Add(item);
            Serialization.WriteToXmlFile(filePath, _document);

            return id;
        }

        public T? get(Predicate<T> query)
        {
            _document = Serialization.ReadFromXmlFile<List<T>>(filePath);
            return _document.Find(query);
        }

        public List<T> getAll(Predicate<T> query)
        {
            _document = Serialization.ReadFromXmlFile<List<T>>(filePath);
            return _document.FindAll(query);
        }

        public bool remove(ID id)
        {
            _document = Serialization.ReadFromXmlFile<List<T>>(filePath);
            foreach (T item in _document)
            {
                if (item.Id.Equals(id))
                {
                    _document.Remove(item);
                    Serialization.WriteToXmlFile(filePath, _document);
                    return true;
                }
            }
            return false;
        }

        public abstract void update(T newItem);
    }
}
