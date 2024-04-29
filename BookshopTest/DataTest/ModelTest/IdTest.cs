using Bookshop.Model.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class IdTest
    {
        [TestMethod]
        public void testEquals()
        {
            ID book1 = new ID(123);
            ID book2 = new ID(123);
            ID book3 = new ID(100);
            ID? bookNull = null;

            Assert.AreEqual(book1, book2);
            Assert.AreNotEqual(book1, book3);
            Assert.AreNotEqual(book1, bookNull);
        }
        [TestMethod]
        public void testIncrement() 
        {
            ID book1 = new ID(100);
            ID book2 = new ID(101);

            Assert.AreNotEqual(book1, book2);
            book1.increment();
            Assert.AreEqual(book1, book2);
        }
    }
}
