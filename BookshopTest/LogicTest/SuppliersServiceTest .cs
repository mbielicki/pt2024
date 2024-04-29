using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic;
using Bookshop.Model.Logic.Suppliers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SuppliersServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            SuppliersService suppliers = new SuppliersService(storage);

            ISupplier supplier = DataGenerator.newSupplier();

            ID id = suppliers.add(supplier);
            Assert.AreEqual(supplier.CompanyName, suppliers.get(id).CompanyName);

            ISupplier identicalSupplier = DataGenerator.copy(supplier);
            Assert.ThrowsException<ItemAlreadyExists>(() => suppliers.add(identicalSupplier));

            ISupplier incorrect = DataGenerator.newSupplier();
            incorrect.ContactInfo = "";

            Assert.ThrowsException<InvalidItemProperties>(() => suppliers.add(incorrect));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            SuppliersService suppliers = new SuppliersService(storage);

            ISupplier supplier = DataGenerator.newSupplier();
            ID id = suppliers.add(supplier);

            ISupplier newSupplier = DataGenerator.copy(supplier);
            newSupplier.ContactInfo = "supplier@company.com";
            suppliers.update(newSupplier);

            Assert.AreEqual(newSupplier.ContactInfo, suppliers.get(id).ContactInfo);

            suppliers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => suppliers.remove(id));
        }
    }
}
