using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Bookshop.Data.Database
{
    internal class CatalogueAPI : IStorageAPI<IBook>
    {

        public ID add(IBook item)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                int newId = database.Books.Max(i => i.BookId) + 1;
                Book newItem = new Book()
                {
                    BookId = newId,
                    Title = item.Title,
                    Author = item.Author,
                    Description = item.Description,
                    Price = item.Price
                };
            

                database.Books.InsertOnSubmit(newItem);
                database.SubmitChanges();

                item.Id = new ID(newId);
                return item.Id;
            }
        }

        public IBook get(Predicate<IBook> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Book, bool> predicate = (book) =>
                {
                    return query(toIBook(book));
                };

                Book? firstResult = database.Books.Where(predicate).First();
                return toIBook(firstResult);
            }
        }

        private IBook toIBook(Model.Book book)
        {
            IBook result = new iBook();
            result.Id = new ID(book.BookId);
            result.Title = book.Title;
            result.Author = book.Author;
            result.Description = book.Description;
            result.Price = book.Price;

            return result;
        }

        public List<IBook> getAll(Predicate<IBook> query)
        {
            throw new NotImplementedException();
        }

        public bool remove(ID id)
        {
            throw new NotImplementedException();
        }

        public void update(IBook book)
        {
        }
    }
}
