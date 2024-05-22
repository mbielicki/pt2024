using Presentation.Commands;
using Presentation.Services;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateCatalogueCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateInvoicesCommand { get; }
        public ICommand NavigateSuppliesCommand { get; }
        public ICommand NavigateInventoryCommand { get; }
        public ICommand NavigateBuyCommand { get; }
        public ICommand NavigateSupplyCommand { get; }
        public NavigationBarViewModel(
            NavigationService<CatalogueViewModel> catalogueNavigationService, 
            NavigationService<CustomersViewModel> customersNavigationService, 
            NavigationService<SuppliersViewModel> suppliersNavigationService, 
            NavigationService<InvoicesViewModel> invoicesNavigationService,
            NavigationService<SuppliesViewModel> suppliesNavigationService,
            NavigationService<InventoryViewModel> inventoryNavigationService,
            NavigationService<BuyViewModel> buyNavigationService,
            NavigationService<SupplyViewModel> supplyNavigationService)
        {
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(catalogueNavigationService);
            NavigateCustomersCommand = new NavigateCommand<CustomersViewModel>(customersNavigationService);
            NavigateSuppliersCommand = new NavigateCommand<SuppliersViewModel>(suppliersNavigationService);
            NavigateInvoicesCommand = new NavigateCommand<InvoicesViewModel>(invoicesNavigationService);
            NavigateSuppliesCommand = new NavigateCommand<SuppliesViewModel>(suppliesNavigationService);
            NavigateInventoryCommand = new NavigateCommand<InventoryViewModel>(inventoryNavigationService);
            NavigateBuyCommand = new NavigateCommand<BuyViewModel>(buyNavigationService);
            NavigateSupplyCommand = new NavigateCommand<SupplyViewModel>(supplyNavigationService);
        }
    }
}
