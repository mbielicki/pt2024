using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Logic;
using Bookshop.Model;
using Bookshop.Stores;
using Bookshop.ViewModel;
using System.Windows;

namespace Bookshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDataLayer dataLayer = new DatabaseBookshopStorage();
            ILogicLayer logicLayer = new LogicLayer(dataLayer);
            IModelLayer modelLayer = new ModelLayer(logicLayer);

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new InvoicesViewModel(navigationStore, modelLayer);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
