using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Logic;
using Bookshop.Presentation.Factories;
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
        private readonly NavigationFactory _navigationFactory;

        public App()
        {
            IDataLayer dataLayer = new DatabaseDataLayer(ConnectionString.Get());
            ILogicLayer logicLayer = new LogicLayer(dataLayer);
            _modelLayer = new ModelLayer(logicLayer);

            _navigationFactory = new NavigationFactory(_modelLayer);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<CatalogueViewModel> catalogueNavigationService 
                = _navigationFactory.CreateCatalogueNavigationService();
            catalogueNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationFactory.NavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }

}
