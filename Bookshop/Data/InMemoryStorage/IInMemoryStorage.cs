﻿using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal abstract class IInMemoryStorage<T> : IStorage<T> where T : HasId
    {
        protected List<T> _document;
        protected ID nextId = new ID();

        public IInMemoryStorage(List<T> document)
        {
            _document = document;
        }

        public ID add(T item)
        {
            ID id = nextId.increment();
            item.Id = id;
            _document.Add(item);
            return id;
        }

        public T? get(Predicate<T> query)
        {
            return _document.Find(query);
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