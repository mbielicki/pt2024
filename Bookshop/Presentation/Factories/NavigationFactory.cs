﻿using Bookshop.Presentation.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.Stores;
using Bookshop.Presentation.ViewModel;

namespace Bookshop.Presentation.Factories
{
    public class NavigationFactory
    {
        public NavigationFactory(IModelLayer modelLayer)
        {
            _modelLayer = modelLayer;

            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(
                CreateCatalogueNavigationService(),
                CreateCustomersNavigationService(),
                CreateSuppliersNavigationService(),
                CreateInvoicesNavigationService(),
                CreateSupplyNavigationService(),
                CreateInventoryNavigationService()
                );
        }

        private readonly IModelLayer _modelLayer;
        private readonly NavigationStore _navigationStore;
        private NavigationBarViewModel _navigationBarViewModel;

        public IModelLayer ModelLayer => _modelLayer;

        public NavigationStore NavigationStore => _navigationStore;

        public NavigationBarViewModel NavigationBarViewModel { get => _navigationBarViewModel; set => _navigationBarViewModel = value; }

        public NavigationService<InventoryViewModel> CreateInventoryNavigationService()
        {
            return new NavigationService<InventoryViewModel>(
                _navigationStore,
                () => new InventoryViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        public NavigationService<CatalogueViewModel> CreateCatalogueNavigationService()
        {
            return new NavigationService<CatalogueViewModel>(
                _navigationStore,
                () => new CatalogueViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        public NavigationService<CustomersViewModel> CreateCustomersNavigationService()
        {
            return new NavigationService<CustomersViewModel>(
                _navigationStore,
                () => new CustomersViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        public NavigationService<InvoicesViewModel> CreateInvoicesNavigationService()
        {
            return new NavigationService<InvoicesViewModel>(
                _navigationStore,
                () => new InvoicesViewModel(_navigationBarViewModel, _modelLayer)
                );
        }

        public NavigationService<SuppliersViewModel> CreateSuppliersNavigationService()
        {
            return new NavigationService<SuppliersViewModel>(
                _navigationStore,
                () => new SuppliersViewModel(_navigationBarViewModel, _modelLayer)
                );
        }
        public NavigationService<SupplyViewModel> CreateSupplyNavigationService()
        {
            return new NavigationService<SupplyViewModel>(
                _navigationStore,
                () => new SupplyViewModel(_navigationBarViewModel, _modelLayer)
                );
        }

    }
}