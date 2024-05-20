using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;

namespace Bookshop.Presentation.Commands
{
    internal class AddBookToCartCommand : CommandBase
    {
        private readonly IShoppingCartViewModel _vm;
        public AddBookToCartCommand(IShoppingCartViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            _vm.AddEmptyRow();
        }
    }
}
