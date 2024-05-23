using Presentation.Model;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.Commands
{
    internal class SupplyCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly SupplyViewModel _vm;
        public SupplyCommand(SupplyViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _modelLayer.Supply(_vm.Supplier, _vm.ShoppingCart, _vm.Price);
            }
            catch (CustomerIdNotFound)
            {
                MessageBox.Show($"No Supplier with id {_vm.Supplier} exists.");
            }
            catch (BookIdNotFound)
            {
                MessageBox.Show($"No Book with id {_vm.SelectedItem.Book.Id} exists.");
            }
            catch (EmptyBookCounterException)
            {
                MessageBox.Show($"Add books to order list");
            }
            catch (BookWithCountZeroInCounterException e)
            {
                MessageBox.Show($"Cannot put zero as count of book \"{_modelLayer.getBook(e.Id).Title}\"");
            }
            finally
            {
                _vm.Clear();
            }
        }
    }
}
