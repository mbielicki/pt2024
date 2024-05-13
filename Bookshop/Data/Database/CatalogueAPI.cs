using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    internal class CatalogueAPI : DatabaseStorage<IBook>
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
