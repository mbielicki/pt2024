using Data.API;
using Data.Model.Entities;

namespace Logic.Catalogue
{
    internal class BookValidator
    {
        private IDataLayer _dataLayer;

        public BookValidator(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public bool haveSameProperties(IBook? a, IBook? b)
        {
            if (a == null || b == null) return false;

            bool bothNullOrEqual(object? a, object? b)
            {
                if (a == null && b == null) return true;
                if (a == null && b != null) return false;
                if (a != null && b == null) return false;
                return a.Equals(b);
            }

            bool nameOk = bothNullOrEqual(a.Title, b.Title);
            bool authorOk = bothNullOrEqual(a.Author, b.Author);
            bool descriptionOk = bothNullOrEqual(a.Description, b.Description);
            bool priceOk = bothNullOrEqual(a.Price, b.Price);

            return nameOk && authorOk && descriptionOk && priceOk;
        }

        internal bool alreadyInCatalogue(IBook book)
        {
            return _dataLayer.Catalogue.get(b => haveSameProperties(book, b)) != null;
        }

        internal bool incorrectProperties(IBook book)
        {
            if (book.Title == null || book.Title == string.Empty) return true;
            if (book.Author == null || book.Author == string.Empty) return true;
            if (book.Price == null || book.Price <= 0) return true;
            if (book.Description == null) book.Description = string.Empty;
            return false;
        }
    }
}
