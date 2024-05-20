using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;
using System.ComponentModel;

namespace Bookshop.Presentation.Commands
{
    public class UpdateBookCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly CatalogueViewModel _vm;
        public UpdateBookCommand(CatalogueViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_vm.CurrentBook))
                OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            _modelLayer.updateBook(_vm.CurrentBook);
        }
        public override bool CanExecute(object parameter)
        {
            return _vm.CurrentBook != null;
        }
    }
}
