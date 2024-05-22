using Presentation.Commands;
using Data.Model.Entities;
using Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private IModelLayer _modelLayer;
        private readonly ObservableCollection<ICustomer> _customers;
        private ICustomer? _currentCustomer;

        public ICommand UpdateCommand { get; }
        public ICommand AddCommand { get; }

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


            UpdateCommand = new UpdateCustomerCommand(this, _modelLayer);
            AddCommand = new AddCustomerCommand(this, _modelLayer);
        }

        internal void AddEmptyRow()
        {
            _customers.Add(new SimpleCustomer()
            {
                Id = _customers.Count
            });
            OnPropertyChanged(nameof(Customers));
        }
    }
}
