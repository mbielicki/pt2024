using Bookshop.Model.Data.API;
using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;

namespace Bookshop.Model.Data.FileSystemStorage.Documents
{
    internal class CatalogueAPI : IStorageAPI<IBook>
    {
        int nextId;
        protected List<Book> _document;
        protected readonly string filePath;

        public CatalogueAPI(string filePath)
        {
            this.filePath = filePath;
            _document = new List<Book>();
            try
            {
                _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            }
            catch (Exception)
            {
                Serialization.WriteToXmlFile(filePath, _document);
                nextId = 0;
            }
            //Serialization.WriteToXmlFile(filePath, new List<T>()); // clear database on every start
        }

        public ID add(IBook item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);
            _document.Add(new Book(item.Id, item.Title, item.Author, item.Description, item.Price));
            Serialization.WriteToXmlFile(filePath, _document);

            return id;
        }

        public IBook? get(Predicate<IBook> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);
            return _document.Find(query);
        }

        public List<IBook> getAll(Predicate<IBook> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);

            return [.. _document.FindAll(query)];
        }

        public bool remove(ID id)
        {
            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);
            foreach (Book item in _document)
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

        public void update(IBook book)
        {
            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);

            IBook bookToUpdate = get(b => b.Id.Equals(book.Id));
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;

            Serialization.WriteToXmlFile(filePath, _document);
        }
    }
}
