using Bookshop;
using System.Configuration;
using System.Data;
using System.Windows;

namespace linq2sqlTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (BookshopDataContext dataContext = new BookshopDataContext())
            {
                IQueryable<Book> books = from book in dataContext.Books
                                         where book.BookId == 0
                                         select book;

                Book b = books.SingleOrDefault();

            }

        }
    }

}
