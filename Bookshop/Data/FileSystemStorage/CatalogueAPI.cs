
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class CatalogueAPI : IFileSystemStorage<Book>
    {
        public CatalogueAPI(string document) : base(document)
        {
        }

        public override void update(Book book)
        {
            Book bookToUpdate = new Book(null, null, null, null, null); //_document.Find(b => b.Id == book.Id);
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;
        }
    }
}
