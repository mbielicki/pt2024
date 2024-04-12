using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class IdTest
    {
        [TestMethod]
        public void testEquals()
        {
            ID book1 = new BookID(123);
            ID book2 = new BookID(123);
            ID book3 = new BookID(100);
            ID? bookNull = null;
            ID customer = new CustomerID(123);

            Assert.AreEqual(book1, book2);
            Assert.AreNotEqual(book1, book3);
            Assert.AreNotEqual(book1, customer);
            Assert.AreNotEqual(book1, bookNull);
        }
        [TestMethod]
        public void testIncrement() 
        {
            ID book1 = new BookID(100);
            ID book2 = new BookID(101);

            Assert.AreNotEqual(book1, book2);
            book1++;
            Assert.AreEqual(book1, book2);
        }
    }
}
