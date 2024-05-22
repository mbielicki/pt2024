using Presentation.Model;
using Presentation.ViewModel;

namespace Presentation.Commands
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
