using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;
using System.Collections.ObjectModel;

namespace Bookshop.ViewModel
{
    class CustomersViewModel : ViewModelBase
    {
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

        public CustomersViewModel()
        {
            _customers = new ObservableCollection<ICustomer>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            CustomersService service = new CustomersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                _customers.Add(service.get(id));
            }
        }
    }
}
