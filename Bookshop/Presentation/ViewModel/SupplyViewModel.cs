using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Bookshop.Logic;
using System.Windows;

namespace Bookshop.Presentation.ViewModel
{
    public class SupplyViewModel : ViewModelBase, IShoppingCartViewModel
    {
        private ObservableCollection<IInventoryEntry> _shoppingCart;
        private IModelLayer _modelLayer;
        private IInventoryEntry _selectedItem;

        public ICommand SupplyCommand { get; }
        public ICommand AddBookToCartCommand { get; }

        public IInventoryEntry SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public IEnumerable<IInventoryEntry> ShoppingCart => _shoppingCart;
        public int Supplier { get; set; } = 0;
        public double Price { get; set; } = 0;

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public SupplyViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _shoppingCart = new ObservableCollection<IInventoryEntry>();

            SupplyCommand = new SupplyCommand(this, _modelLayer);
            AddBookToCartCommand = new AddBookToCartCommand(this);
        }

        public void AddEmptyRow()
        {
            _shoppingCart.Add(new SimpleInventoryEntry()
            {
                Book = new SimpleBook()
                {
                    Id = 0
                },
                Count = 0
            });
        }

        internal void Clear()
        {
            _shoppingCart.Clear();
        }
    }
}
