using Bookshop.Data;
using Bookshop.Data.Model;

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
                throw new IncorrectBookProperties();

            if (_validator.alreadyInStorage(book))
                throw new BookAlreadyExists();

            return _storage.add(book);
        }

        public Book get(int bookId)
        {
            Book? result = _storage.get(b => b.Id == bookId);
            if (result == null) 
                throw new IncorrectBookProperties();
            return result;
        }

        public void remove(int bookId)
        {
            throw new NotImplementedException();
        }

        public void update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
