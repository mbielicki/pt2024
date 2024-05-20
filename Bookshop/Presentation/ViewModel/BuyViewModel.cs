using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Bookshop.Logic;
using System.Windows;

namespace Bookshop.Presentation.ViewModel
{
    public class BuyViewModel : ViewModelBase
    {
        private ObservableCollection<IInventoryEntry> _shoppingCart;
        private IModelLayer _modelLayer;
        private IInventoryEntry _selectedItem;

        public ICommand BuyCommand { get; }
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
        public int Customer { get; set; } = 0;
        public double Price
        {
            get
            {
                try
                {
                    return _modelLayer.CheckPrice(_shoppingCart);
                } catch (BookIdNotFound)
                {
                    MessageBox.Show($"No Book with id {_selectedItem.Book.Id} exists.");
                    return 0;
                }
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public BuyViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _shoppingCart = new ObservableCollection<IInventoryEntry>();

            BuyCommand = new BuyCommand(this, _modelLayer);
            AddBookToCartCommand = new AddBookToCartCommand(this);
        }

        internal void AddEmptyRow()
        {
            _shoppingCart.Add(new PropertyChangeInventoryEntry(() => OnPropertyChanged(nameof(Price)))
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
            OnPropertyChanged(nameof(Price));
        }

        private class PropertyChangeInventoryEntry : IInventoryEntry
        {
            Action _onPropertyChanged;
            private IBook _book;
            private int _count;

            public PropertyChangeInventoryEntry(Action onPropertyChanged)
            {
                _onPropertyChanged = onPropertyChanged;
            }
            public IBook Book 
            {
                get => _book; 
                set
                {
                    _book = value;
                    _onPropertyChanged();
                }
            }
            public int Count
            {
                get => _count;
                set
                {
                    _count = value;
                    _onPropertyChanged();
                }
            }
        }
    }
}
