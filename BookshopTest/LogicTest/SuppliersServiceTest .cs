using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SuppliersServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<ISupplier> suppliers = logic.SuppliersService;

            ISupplier supplier = DataGenerator.newSupplier();

            int id = suppliers.add(supplier);
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
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IService<ISupplier> suppliers = logic.SuppliersService;

            ISupplier supplier = DataGenerator.newSupplier();
            int id = suppliers.add(supplier);

            ISupplier newSupplier = DataGenerator.copy(supplier);
            newSupplier.ContactInfo = "supplier@company.com";
            suppliers.update(newSupplier);

            Assert.AreEqual(newSupplier.ContactInfo, suppliers.get(id).ContactInfo);

            suppliers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => suppliers.remove(id));
        }
    }
}
