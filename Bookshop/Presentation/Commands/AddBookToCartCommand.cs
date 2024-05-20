using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;

namespace Bookshop.Presentation.Commands
{
    internal class AddBookToCartCommand : CommandBase
    {
        private readonly BuyViewModel _vm;
        public AddBookToCartCommand(BuyViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            _vm.AddEmptyRow();
        }
    }
}
