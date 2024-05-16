using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Model
{
    public static class Converter
    {
        public static IBook ToIBook(this Book book)
        {
            IBook result = new SimpleBook();
            result.Id = book.BookId;
            result.Title = book.Title;
            result.Author = book.Author;
            result.Description = book.Description;
            result.Price = book.Price;

            return result;
        }

        public static List<IBook> ToIBook(this IEnumerable<Book> books)
        {
            List<IBook> result = new List<IBook>();
            foreach (var book in books)
            {
                result.Add(book.ToIBook());
            }
            return result;
        }


        public static ICustomer ToICustomer(this Customer item)
        {
            return new SimpleCustomer()
            {
                Id = item.CustomerId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                ContactInfo = item.ContactInfo
            };
        }
        public static List<ICustomer> ToICustomer(this IEnumerable<Customer> items)
        {
            List<ICustomer> result = new List<ICustomer>();
            foreach (var item in items)
            {
                result.Add(ToICustomer(item));
            }
            return result;
        }

        public static List<ISupplier> ToISupplier(this IEnumerable<Supplier> items)
        {
            List<ISupplier> result = new List<ISupplier>();
            foreach (var item in items)
            {
                result.Add(ToISupplier(item));
            }
            return result;
        }

        public static ISupplier ToISupplier(this Supplier item)
        {
            return new SimpleSupplier()
            {
                Id = item.SupplierId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                CompanyName = item.CompanyName,
                Address = item.Address,
                ContactInfo = item.ContactInfo
            };
        }

    }
}
