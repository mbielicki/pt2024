using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic;

namespace Bookshop.Model.Logic.Catalogue
{
    public class CatalogueService : IService<IBook>
    {
        private IBookshopStorage _storage;
        private BookValidator _validator;
        public CatalogueService(IBookshopStorage storage)
        {
            _storage = storage;
            _validator = new BookValidator(storage);
        }
        public ID add(IBook book)
        {
            if (_validator.incorrectProperties(book))
                throw new InvalidItemProperties();

            if (_validator.alreadyInCatalogue(book))
                throw new ItemAlreadyExists();

            return _storage.Catalogue.add(book);
        }

        public IBook get(ID bookId)
        {
            IBook? result = _storage.Catalogue.get(b => b.Id.Equals(bookId));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<ID> getIds()
        {
            return _storage.Catalogue.getAll((i) => true).ConvertAll(i => i.Id);

        }

        public void remove(ID bookId)
        {
            if (_storage.Catalogue.remove(bookId)) return;
            throw new ItemIdNotFound();
        }

        public void update(IBook newBook)
        {
            if (_validator.incorrectProperties(newBook))
                throw new InvalidItemProperties();
            try
            {
                _storage.Catalogue.update(newBook);

            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }

        }
    }
}
