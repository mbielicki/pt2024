using Data.API;
using Logic.Model;

namespace Logic.Catalogue
{
    public class CatalogueService : IService<Model.Entities.IBook>
    {
        private IDataLayer _dataLayer;
        private BookValidator _validator;
        public CatalogueService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new BookValidator(dataLayer);
        }
        public int add(Model.Entities.IBook book)
        {
            if (_validator.incorrectProperties(book.ToData()))
                throw new InvalidItemProperties();

            if (_validator.alreadyInCatalogue(book.ToData()))
                throw new ItemAlreadyExists();

            return _dataLayer.Catalogue.add(book.ToData());
        }

        public Model.Entities.IBook get(int bookId)
        {
            Data.Model.Entities.IBook? result = _dataLayer.Catalogue.get(b => b.Id.Equals(bookId));
            if (result == null)
                throw new BookIdNotFound();
            return result.ToLogic();
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

        public void update(Model.Entities.IBook newBook)
        {
            if (_validator.incorrectProperties(newBook.ToData()))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Catalogue.update(newBook.ToData());

            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }

        }
    }
}
