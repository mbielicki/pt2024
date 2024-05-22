using Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void testCounter()
        {
            Counter<int> counter = new Counter<int> ();

            counter.Add(25);
            counter.Add(3);
            counter.Add(25);
            Assert.AreEqual(1, counter.Get(num => num == 3));
            Assert.AreEqual(2, counter.Get(num => num == 25));

            counter.RemoveOne(25);
            Assert.AreEqual(1, counter.Get(num => num == 25));
            counter.RemoveOne(25);
            Assert.AreEqual(0, counter.Get(num => num == 25));
            
            Assert.ThrowsException<KeyNotFoundException>(() => counter.RemoveOne(25));

        }
    }
}
