using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class CatalogueAPI : IInMemoryStorage<IBook>
    {
        public CatalogueAPI(List<IBook> document) : base(document)
        {
        }

        public override void update(IBook book)
        {
            IBook bookToUpdate = _document.Find(b => b.Id.Equals(book.Id));
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }
    }
}
