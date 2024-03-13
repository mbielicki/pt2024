using Task_0;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator calculator = new Calculator(); 
            int result = calculator.add(2, 2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestRemove()
        {
            Calculator calculator = new Calculator(); 
            int result = calculator.remove(4, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Calculator calculator = new Calculator(); 
            int result = calculator.multiply(4, 2);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            Calculator calculator = new Calculator(); 
            int result = calculator.divide(6, 2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            Calculator calculator = new Calculator();
            Assert.ThrowsException<ArithmeticException>(() => calculator.divide(6, 0));
        }
    }
}