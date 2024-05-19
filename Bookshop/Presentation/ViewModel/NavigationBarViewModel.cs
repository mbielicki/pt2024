using Bookshop.Presentation.Commands;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.ViewModel;
using System.Windows.Input;

namespace Bookshop.Presentation.ViewModel
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }
        public ICommand NavigateSupplyCommand { get; }
        public NavigationBarViewModel(
            NavigationService<CatalogueViewModel> catalogueNavigationService, 
            NavigationService<CustomersViewModel> customersNavigationService, 
            NavigationService<SuppliersViewModel> suppliersNavigationService, 
            NavigationService<InvoicesViewModel> invoicesNavigationService,
            NavigationService<SupplyViewModel> supplyNavigationService)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(catalogueNavigationService);
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(customersNavigationService);
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(suppliersNavigationService);
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(invoicesNavigationService);
            NavigateSupplyCommand = new NavigateCommand<SupplyViewModel>(supplyNavigationService);
        }
    }
}
