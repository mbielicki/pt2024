using Bookshop;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void getBook()
        {
            using(BookshopDataContext dataContext = new BookshopDataContext())
            {
                IQueryable<Book> books = from book in dataContext.Books 
                            where book.BookId == 0 
                            select book;

                Book b = books.SingleOrDefault();

                Assert.AreEqual(b.Author, "Adam Mickewicz");
            }
        }

    }
}
