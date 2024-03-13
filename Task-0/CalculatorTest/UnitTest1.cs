using Task_0;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            int result = Calculator.add(2, 2);
            Assert.AreEqual(4, result);
        }
    }
}