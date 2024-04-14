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
            _document = Serialization.ReadFromXmlFile<List<Book>>(filePath);

            Book bookToUpdate = get(b => b.Id.Equals(book.Id));
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Price = book.Price;

            Serialization.WriteToXmlFile(filePath, _document);
        }
    }
}
