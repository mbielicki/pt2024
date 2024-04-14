using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Suppliers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SuppliersServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            SuppliersService suppliers = new SuppliersService(storage);

            Supplier supplier = DataGenerator.newSupplier();

            ID id = suppliers.add(supplier);
            Assert.AreEqual(id, suppliers.getIds()[0]);

            Supplier identicalSupplier = DataGenerator.copy(supplier);
            Assert.ThrowsException<ItemAlreadyExists>(() => suppliers.add(identicalSupplier));

            Supplier incorrect = DataGenerator.newSupplier();
            incorrect.ContactInfo = "";

            Assert.ThrowsException<InvalidItemProperties>(() => suppliers.add(incorrect));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            SuppliersService suppliers = new SuppliersService(storage);

            Supplier supplier = DataGenerator.newSupplier();
            ID id = suppliers.add(supplier);

            Supplier newSupplier = DataGenerator.copy(supplier);
            newSupplier.ContactInfo = "supplier@company.com";
            suppliers.update(newSupplier);

            Assert.AreEqual(newSupplier.ContactInfo, suppliers.get(id).ContactInfo);

            suppliers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => suppliers.remove(id));
        }
    }
}
