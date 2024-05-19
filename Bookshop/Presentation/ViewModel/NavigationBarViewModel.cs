using Bookshop.Commands;
using Bookshop.Model;
using Bookshop.Stores;
using Bookshop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshop.Presentation.ViewModel
{
    public class NavigationBarViewModel
    {
        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }
        public NavigationBarViewModel(NavigationStore navigationStore, IModelLayer modelLayer)
        {
            //NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(
            //    navigationStore, () => new CatalogueViewModel(navigationStore, modelLayer));

            //NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(
            //    navigationStore, () => new CustomersViewModel(navigationStore, modelLayer));

            //NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(
            //    navigationStore, () => new SuppliersViewModel(navigationStore, modelLayer));

            //NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(
            //    navigationStore, () => new InvoicesViewModel(navigationStore, modelLayer));
        }
    }
}
