using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;

namespace Bookshop.Presentation.Commands
{
    public class AddCustomerCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly CustomersViewModel _vm;
        public AddCustomerCommand(CustomersViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;
        }

        public override void Execute(object parameter)
        {
            _vm.AddEmptyRow();
        }
    }
}
