using Data.Model.Entities;
using Logic;
using Presentation.Model;
using Presentation.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Presentation.Commands
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
            try
            {
                try
                {
                    _modelLayer.updateBook(_vm.CurrentBook);
                }
                catch (InvalidOperationException)
                {
                    _modelLayer.addBook(_vm.CurrentBook);
                }
            }
            catch (InvalidItemProperties)
            {
                MessageBox.Show("Item cannot be created because it has incorrect properties.");
            }
        }
        public override bool CanExecute(object parameter)
        {
            return _vm.CurrentBook != null;
        }
    }
}
