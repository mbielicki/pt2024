using Presentation.Commands;
using Model.Model.Entities;
using Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class SuppliersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupplier> _suppliers;
        private ISupplier? _currentSupplier;
        private IModelLayer _modelLayer;

        public ICommand UpdateCommand { get; }
        public ICommand AddCommand { get; }
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

            UpdateCommand = new UpdateSupplierCommand(this, _modelLayer);
            AddCommand = new AddSupplierCommand(this, _modelLayer);
        }

        internal void AddEmptyRow()
        {
            _suppliers.Add(new SimpleSupplier()
            {
                Id = _suppliers.Count
            });
            OnPropertyChanged(nameof(Suppliers));
        }
    }
}
