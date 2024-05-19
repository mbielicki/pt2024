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
    public class SuppliersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupplier> _suppliers;
        private ISupplier? _currentSupplier;
        private IModelLayer _modelLayer;

        public IEnumerable<ISupplier> Suppliers => _suppliers;

        public ISupplier? CurrentSupplier
        {
            get => _currentSupplier;
            set
            {
                _currentSupplier = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public SuppliersViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _suppliers = _modelLayer.getSuppliersObservable();
        }
    }
}
