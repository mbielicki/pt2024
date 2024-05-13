using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void testCounter()
        {
            Counter<ID> counter = new Counter<ID> ();

            counter.Add(new ID(25));
            counter.Add(new ID(3));
            counter.Add(new ID(25));
            Assert.AreEqual(1, counter.Get(num => num.Equals(new ID(3))));
            Assert.AreEqual(2, counter.Get(num => num.Equals(new ID(25))));

            counter.RemoveOne(new ID(25));
            Assert.AreEqual(1, counter.Get(num => num.Equals(new ID(25))));
            counter.RemoveOne(new ID(25));
            Assert.AreEqual(0, counter.Get(num => num.Equals(new ID(25))));
            
            Assert.ThrowsException<KeyNotFoundException>(() => counter.RemoveOne(new ID(25)));

        }
    }
}
