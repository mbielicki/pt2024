using Presentation.Factories;
using Presentation.Model;
using Presentation.ViewModel;
using BookshopTest.DataGeneration;

namespace BookshopTest.ViewModelTest
{
    [TestClass]
    public class NavigationBarViewModelTest
    {
        [TestMethod]
        public void navigateTest()
        {
            //IModelLayer modelLayer = new InMemoryMockModelLayer();
            IModelLayer modelLayer = new SampleMockModelLayer();
            NavigationFactory navigation = new NavigationFactory(modelLayer);
            NavigationBarViewModel vm = navigation.NavigationBarViewModel;

            Assert.IsNotNull(vm);
            Assert.IsTrue(vm.NavigateCatalogueCommand.CanExecute(null));
            Assert.IsTrue(vm.NavigateCustomersCommand.CanExecute(null));
            Assert.IsTrue(vm.NavigateSuppliersCommand.CanExecute(null));
            Assert.IsTrue(vm.NavigateInventoryCommand.CanExecute(null));
            Assert.IsTrue(vm.NavigateInvoicesCommand.CanExecute(null));
            Assert.IsTrue(vm.NavigateSuppliesCommand.CanExecute(null));

            vm.NavigateCatalogueCommand.Execute(null);
            Assert.IsInstanceOfType<CatalogueViewModel>(navigation.NavigationStore.CurrentViewModel);
            vm.NavigateCustomersCommand.Execute(null);
            Assert.IsInstanceOfType<CustomersViewModel>(navigation.NavigationStore.CurrentViewModel);
            vm.NavigateSuppliersCommand.Execute(null);
            Assert.IsInstanceOfType<SuppliersViewModel>(navigation.NavigationStore.CurrentViewModel);
            vm.NavigateInventoryCommand.Execute(null);
            Assert.IsInstanceOfType<InventoryViewModel>(navigation.NavigationStore.CurrentViewModel);
            vm.NavigateInvoicesCommand.Execute(null);
            Assert.IsInstanceOfType<InvoicesViewModel>(navigation.NavigationStore.CurrentViewModel);
            vm.NavigateSuppliesCommand.Execute(null);
            Assert.IsInstanceOfType<SuppliesViewModel>(navigation.NavigationStore.CurrentViewModel);
        }
    }
}
