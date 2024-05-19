using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.ViewModel;
using Bookshop.Presentation.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.Presentation.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private IModelLayer _modelLayer;
        private readonly ObservableCollection<ICustomer> _customers;
        private ICustomer? _currentCustomer;

        public IEnumerable<ICustomer> Customers => _customers;

        public ICustomer? CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public CustomersViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _customers = _modelLayer.getCustomersObservable();
        }
    }
}
