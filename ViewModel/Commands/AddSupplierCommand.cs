using Presentation.Model;
using Presentation.ViewModel;

namespace Presentation.Commands
{
    public class AddSupplierCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly SuppliersViewModel _vm;
        public AddSupplierCommand(SuppliersViewModel vm, IModelLayer modelLayer)
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
