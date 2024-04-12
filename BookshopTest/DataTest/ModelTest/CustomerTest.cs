using Bookshop.Data.Model;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void testCustomerInit()
        {
            ID id = new ID();
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(id, firstName, lastName, address, contactInfo);
            Assert.AreEqual(id, customer.Id);
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.LastName);
            Assert.AreEqual(address, customer.Address);
            Assert.IsNull(customer.ContactInfo);
        }
    }
}
