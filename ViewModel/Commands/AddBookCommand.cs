using Presentation.Model;
using Presentation.ViewModel;

namespace Presentation.Commands
{
    public class AddBookCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly CatalogueViewModel _vm;
        public AddBookCommand(CatalogueViewModel vm, IModelLayer modelLayer)
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
