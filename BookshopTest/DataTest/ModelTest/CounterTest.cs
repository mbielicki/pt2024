using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void testCounter()
        {
            Counter<int> counter = new Counter<int> ();

            counter.add(25);
            counter.add(3);
            counter.add(25);
            Assert.AreEqual(0, counter.get(10));
            Assert.AreEqual(1, counter.get(3));
            Assert.AreEqual(2, counter.get(25));

            counter.remove(25);
            Assert.AreEqual(1, counter.get(25));
            counter.remove(25);
            Assert.AreEqual(0, counter.get(25));
            
            Assert.ThrowsException<KeyNotFoundException>(() => counter.remove(25));

        }
    }
}
