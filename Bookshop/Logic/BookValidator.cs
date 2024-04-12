using Bookshop.Data;
using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    internal class BookValidator
    {
        private IStorage _storage;

        public BookValidator(IStorage storage) 
        {
            _storage = storage;
        }
        public bool haveSameProperties(Book? a, Book? b)
        {
            if (a == null || b == null) return false;

            bool bothNullOrEqual(object? a, object? b)
            {
                if (a == null && b == null) return true;
                if (a == null && b != null) return false;
                if (a != null && b == null) return false;
                return a.Equals(b);
            }

            bool nameOk = bothNullOrEqual(a.Name, b.Name);
            bool authorOk = bothNullOrEqual(a.Author, b.Author);
            bool descriptionOk = bothNullOrEqual(a.Description, b.Description);
            bool priceOk = bothNullOrEqual(a.Price, b.Price);

            return nameOk && authorOk && descriptionOk && priceOk;
        }

        internal bool alreadyInStorage(Book book)
        {
            return _storage.get(b => haveSameProperties(book, b)) != null;
        }

        internal bool incorrectProperties(Book book)
        {
            if (book.Name == null || book.Name == string.Empty) return true;
            if (book.Author == null || book.Author == string.Empty) return true;
            if (book.Price == null || book.Price <= 0) return true;
            return false;
        }
    }
}
