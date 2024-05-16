using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

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

        public IBook? get(Predicate<IBook> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Book, bool> predicate = (book) =>
                {
                    return query(toIBook(book));
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
                return toIBook(firstResult);
            }
        }

        private IBook toIBook(Book book)
        {
            IBook result = new SimpleBook();
            result.Id = new ID(book.BookId);
            result.Title = book.Title;
            result.Author = book.Author;
            result.Description = book.Description;
            result.Price = book.Price;

            return result;
        }

        private List<IBook> toIBook(IEnumerable<Book> books)
        {
            List<IBook> result = new List<IBook>();
            foreach (var book in books)
            {
                result.Add(toIBook(book));
            }
            return result;
        }

        public List<IBook> getAll(Predicate<IBook> query)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Func<Book, bool> predicate = (book) =>
                {
                    return query(toIBook(book));
                };

                IEnumerable<Book> result = database.Books.Where(predicate);
                return toIBook(result);
            }
        }

        public bool remove(ID id)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {

                var result = from book in database.Books
                                    where book.BookId == id.Value
                                    select book;

                try
                {
                    database.Books.DeleteOnSubmit(result.Single());
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
                var query = from b in database.Books
                             where b.BookId == book.Id.Value
                             select b;

                try
                {
                    Book dbBook = query.Single();

                    dbBook.Title = book.Title;
                    dbBook.Description = book.Description;
                    dbBook.Author = book.Author;
                    dbBook.Price = book.Price;

                    database.SubmitChanges();
                } catch (Exception ex)
                {

                }
            }
        }
    }
}
