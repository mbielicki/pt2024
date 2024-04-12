using Bookshop.Data;
using Bookshop.Data.Model;
using System.Net;

namespace Bookshop.Logic
{
    public class CatalogueService : IService
    {
        private IStorage _storage;
        private BookValidator _validator;
        public CatalogueService(IStorage storage) 
        {
            _storage = storage;
            _validator = new BookValidator(storage);
        }
        public int add(Book book)
        {
            if (_validator.incorrectProperties(book))
                throw new InvalidBookProperties();

            if (_validator.alreadyInStorage(book))
                throw new BookAlreadyExists();

            return _storage.add(book);
        }

        public Book get(int bookId)
        {
            Book? result = _storage.get(b => b.Id == bookId);
            if (result == null) 
                throw new BookIdNotFound();
            return result;
        }

        public void remove(int bookId)
        {
            if (_storage.remove(bookId)) return;
            throw new BookIdNotFound();
        }

        public void update(Book newBook)
        {
            if (_validator.incorrectProperties(newBook))
                throw new InvalidBookProperties();
            Book? result = _storage.get(b => b.Id == newBook.Id);
            if (result == null)
                throw new BookIdNotFound();

            result.Name = newBook.Name;
            result.Author = newBook.Author;
            result.Description = newBook.Description;
            result.Price = newBook.Price;
        }
    }
}
