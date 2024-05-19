using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Logic;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.Stores;
using Bookshop.Presentation.ViewModel;
using Bookshop.Presentation.ViewModel;
using System.Windows;

namespace Bookshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IModelLayer _modelLayer;
        private readonly NavigationStore _navigationStore;
        private NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            IDataLayer dataLayer = new DatabaseBookshopStorage();
            ILogicLayer logicLayer = new LogicLayer(dataLayer);
            _modelLayer = new ModelLayer(logicLayer);

            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(
                CreateCatalogueNavigationService(),
                CreateCustomersNavigationService(),
                CreateSuppliersNavigationService(),
                CreateInvoicesNavigationService()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<CatalogueViewModel> catalogueNavigationService = CreateCatalogueNavigationService();
            catalogueNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<CatalogueViewModel> CreateCatalogueNavigationService()
        {
            return new NavigationService<CatalogueViewModel>(
                _navigationStore,
                () => new CatalogueViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        private NavigationService<CustomersViewModel> CreateCustomersNavigationService()
        {
            return new NavigationService<CustomersViewModel>(
                _navigationStore,
                () => new CustomersViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        private NavigationService<InvoicesViewModel> CreateInvoicesNavigationService()
        {
            return new NavigationService<InvoicesViewModel>(
                _navigationStore,
                () => new InvoicesViewModel(_navigationBarViewModel, _modelLayer)
                );
        }

        private NavigationService<SuppliersViewModel> CreateSuppliersNavigationService()
        {
            return new NavigationService<SuppliersViewModel>(
                _navigationStore,
                () => new SuppliersViewModel(_navigationBarViewModel, _modelLayer)
                );
        }

    }

}
