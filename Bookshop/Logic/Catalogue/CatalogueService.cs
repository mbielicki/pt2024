using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic.Catalogue
{
    public class CatalogueService : IService<IBook>
    {
        private IDataLayer _storage;
        private BookValidator _validator;
        public CatalogueService(IDataLayer storage)
        {
            _storage = storage;
            _validator = new BookValidator(storage);
        }
        public int add(IBook book)
        {
            if (_validator.incorrectProperties(book))
                throw new InvalidItemProperties();

            if (_validator.alreadyInCatalogue(book))
                throw new ItemAlreadyExists();

            return _storage.Catalogue.add(book);
        }

        public IBook get(int bookId)
        {
            IBook? result = _storage.Catalogue.get(b => b.Id.Equals(bookId));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _storage.Catalogue.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int bookId)
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
