using Bookshop.Logic;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Bookshop.Presentation.Commands
{
    public class UpdateSupplierCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly SuppliersViewModel _vm;
        public UpdateSupplierCommand(SuppliersViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_vm.CurrentSupplier))
                OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            try
            {
                try
                {
                    _modelLayer.updateSupplier(_vm.CurrentSupplier);
                }
                catch (InvalidOperationException)
                {
                    _modelLayer.addSupplier(_vm.CurrentSupplier);
                }
            }
            catch (InvalidItemProperties)
            {
                MessageBox.Show("Item cannot be created because it has incorrect properties.");
            }
        }
        public override bool CanExecute(object parameter)
        {
            return _vm.CurrentSupplier != null;
        }
    }
}
