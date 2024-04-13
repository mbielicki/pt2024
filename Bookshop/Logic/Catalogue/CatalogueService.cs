using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic.Catalogue
{
    public class CatalogueService : IService<Book>
    {
        private IBookshopStorage _storage;
        private BookValidator _validator;
        public CatalogueService(IBookshopStorage storage)
        {
            _storage = storage;
            _validator = new BookValidator(storage);
        }
        public ID add(Book book)
        {
            if (_validator.incorrectProperties(book))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(book))
                throw new ItemAlreadyExists();

            return _storage.Catalogue.add(book);
        }

        public Book get(ID bookId)
        {
            Book? result = _storage.Catalogue.get(b => b.Id == bookId);
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public void remove(ID bookId)
        {
            if (_storage.Catalogue.remove(bookId)) return;
            throw new ItemIdNotFound();
        }

        public void update(Book newBook)
        {
            if (_validator.incorrectProperties(newBook))
                throw new InvalidItemProperties();
            Book? result = _storage.Catalogue.get(b => b.Id == newBook.Id);
            if (result == null)
                throw new ItemIdNotFound();

            result.Name = newBook.Name;
            result.Author = newBook.Author;
            result.Description = newBook.Description;
            result.Price = newBook.Price;
        }
    }
}
