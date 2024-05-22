using Data.API;
using Data.Model.Entities;

namespace Logic.Catalogue
{
    public class CatalogueService : IService<IBook>
    {
        private IDataLayer _dataLayer;
        private BookValidator _validator;
        public CatalogueService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new BookValidator(dataLayer);
        }
        public int add(IBook book)
        {
            if (_validator.incorrectProperties(book))
                throw new InvalidItemProperties();

            if (_validator.alreadyInCatalogue(book))
                throw new ItemAlreadyExists();

            return _dataLayer.Catalogue.add(book);
        }

        public IBook get(int bookId)
        {
            IBook? result = _dataLayer.Catalogue.get(b => b.Id.Equals(bookId));
            if (result == null)
                throw new BookIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _dataLayer.Catalogue.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int bookId)
        {
            if (_dataLayer.Catalogue.remove(bookId)) return;
            throw new ItemIdNotFound();
        }

        public void update(IBook newBook)
        {
            if (_validator.incorrectProperties(newBook))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Catalogue.update(newBook);

            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }

        }
    }
}
