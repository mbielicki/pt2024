using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class CatalogueAPI : IInMemoryStorage<Book>
    {
        public CatalogueAPI(List<Book> document) : base(document)
        {
        }

        public override void update(Book book)
        {
            Book bookToUpdate = _document.Find(b => b.Id.Equals(book.Id));
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }
    }
}
