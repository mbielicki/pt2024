using Presentation.Model;
using System.Collections.ObjectModel;
using Model.Model.Entities;

namespace ModelTest
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void TestCreate()
        {
            IModelLayer modelLayer = new ModelLayer(new MockLogicLayer.MockLogicLayer());

            Assert.IsNotNull(modelLayer.getBook(0));
            Assert.IsNotNull(modelLayer.getBooksObservable());
            Assert.IsNotNull(modelLayer.getCustomersObservable());
            Assert.IsNotNull(modelLayer.getSuppliersObservable());
            Assert.IsNotNull(modelLayer.getInventoryObservable());
            Assert.IsNotNull(modelLayer.getSuppliesObservable());

            Assert.AreEqual(0, modelLayer.CheckPrice(new ObservableCollection<IInventoryEntry>()));
        }
    }
}