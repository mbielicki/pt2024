using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void testBookInit()
        {
            int id = 0;
            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(id, name, author, description, price);

            Assert.AreEqual(book.Id, id);
            Assert.AreEqual(book.Name, name);
            Assert.AreEqual(book.Author, author);
            Assert.AreEqual(book.Description, description);
            Assert.AreEqual(book.Price, price);
        }

    }
}
