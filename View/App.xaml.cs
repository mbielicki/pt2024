using Presentation.Factories;
using Presentation.Services;
using Presentation.ViewModel;
using System.Windows;

namespace Bookshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationFactory _navigationFactory;

        public App()
        {
            _navigationFactory = NavigationFactory.GetInstance();
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
