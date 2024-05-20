using Bookshop.Presentation.Factories;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;
using BookshopTest.DataGeneration;

namespace BookshopTest.ViewModelTest
{
    [TestClass]
    public class CatalogueViewModelTest
    {
        [TestMethod]
        public void creatorTest()
        {
            IModelLayer modelLayer = new InMemoryMockModelLayer();
            NavigationFactory navigation = new NavigationFactory(modelLayer);
            CatalogueViewModel vm = new CatalogueViewModel(navigation.NavigationBarViewModel, modelLayer);

            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.NavigationBarViewModel);
            Assert.IsNotNull(vm.Catalogue);
            Assert.IsNull(vm.CurrentBook);
            
        }
    }
}
