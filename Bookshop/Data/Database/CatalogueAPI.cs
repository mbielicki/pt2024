using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;
using static Bookshop.Data.Model.Converter;

namespace Bookshop.Data.Database
{
    internal class CatalogueAPI : IStorageAPI<IBook>
    {

        public int add(IBook item)
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

                item.Id = newId;
                return (int) item.Id;
            }
        }

        public IBook? get(Predicate<IBook> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Book, bool> predicate = (book) =>
                {
                    return query(book.ToIBook());
                };

                IEnumerable<Book> result = database.Books.Where(predicate);
                Book firstResult;
                try
                {
                    firstResult = result.First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
                return firstResult.ToIBook();
            }
        }

        public List<IBook> getAll(Predicate<IBook> query)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Func<Book, bool> predicate = (book) =>
                {
                    return query(book.ToIBook());
                };

                IEnumerable<Book> result = database.Books.Where(predicate);
                return result.ToIBook();
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {

                var query = from book in database.Books
                                    where book.BookId == id
                                    select book;

                //var query = database.Books.Where(b => b.BookId == id).Select(b => b);

                try
                {
                    database.Books.DeleteOnSubmit(query.Single());
                    database.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void update(IBook book)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                //var query = from b in database.Books
                //             where b.BookId == book.Id
                //             select b;

                var query = database.Books.Where(b => b.BookId == book.Id).Select(b => b);

                Book dbBook = query.Single();

                dbBook.Title = book.Title;
                dbBook.Description = book.Description;
                dbBook.Author = book.Author;
                dbBook.Price = book.Price;

                database.SubmitChanges();
            }
        }
    }
}
