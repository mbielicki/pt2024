using Logic;
using Presentation.Model;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.Commands
{
    internal class BuyCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly BuyViewModel _vm;
        public BuyCommand(BuyViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;
        }
        public override void Execute(object parameter)
        {
            if (_vm.Price == 0)
            {
                MessageBox.Show("Select books to buy.");
                return;
            }
            try
            {
                _modelLayer.Buy(_vm.Customer, _vm.ShoppingCart);
            }
            catch (CustomerIdNotFound)
            {
                MessageBox.Show($"No Customer with id {_vm.Customer} exists.");
            }
            catch (BookIdNotFound)
            {
                MessageBox.Show($"No Book with id {_vm.SelectedItem.Book.Id} exists.");
            }
            catch (NotEnoughItemsInInventory e)
            {
                MessageBox.Show($"Not enough items {_modelLayer.getBook(e.Id).Title} in inventory.");
            }
            finally
            {
                _vm.Clear();
            }
        }
    }
}
