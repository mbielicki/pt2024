using Data.Model.Entities;

namespace BookshopTest.DataTest.ModelTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void testCustomerInit()
        {
            int id = 0;
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            SimpleCustomer customer = new SimpleCustomer(id, firstName, lastName, address, contactInfo);
            Assert.AreEqual(id, customer.Id);
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.LastName);
            Assert.AreEqual(address, customer.Address);
            Assert.IsNull(customer.ContactInfo);
        }
    }
}
