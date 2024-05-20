using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.Presentation.ViewModel
{
    public class BuyViewModel : ViewModelBase
    {
        private IInvoice _shoppingCart;
        private IModelLayer _modelLayer;

        public ICommand BuyCommand { get; }


        public IInvoice ShoppingCart
        {
            get => _shoppingCart;
            set
            {
                _shoppingCart = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public BuyViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _shoppingCart = new SimpleInvoice();

            BuyCommand = new BuyCommand(this, _modelLayer);

        }
    }
}
