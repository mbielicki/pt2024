using Data.API;
using Data.Database;
using Logic;
using Presentation.Factories;
using Presentation.Model;
using Presentation.Services;
using Presentation.Stores;
using Presentation.ViewModel;
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
