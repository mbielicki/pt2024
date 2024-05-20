using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;

namespace Bookshop.Presentation.Commands
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
            throw new NotImplementedException();
        }
    }
}
