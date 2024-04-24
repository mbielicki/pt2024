using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic.Catalogue
{
    internal class BookValidator
    {
        private IBookshopStorage _storage;

        public BookValidator(IBookshopStorage storage)
        {
            _storage = storage;
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
            return _storage.Catalogue.get(b => haveSameProperties(book, b)) != null;
        }

        internal bool incorrectProperties(IBook book)
        {
            if (book.Title == null || book.Title == string.Empty) return true;
            if (book.Author == null || book.Author == string.Empty) return true;
            if (book.Price == null || book.Price <= 0) return true;
            return false;
        }
    }
}
