using Logic;
using Presentation.Model;
using Presentation.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Presentation.Commands
{
    public class UpdateCustomerCommand : CommandBase
    {
        private readonly IModelLayer _modelLayer;
        private readonly CustomersViewModel _vm;
        public UpdateCustomerCommand(CustomersViewModel vm, IModelLayer modelLayer)
        {
            _vm = vm;
            _modelLayer = modelLayer;

            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_vm.CurrentCustomer))
                OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            try
            {
                try
                {
                    _modelLayer.updateCustomer(_vm.CurrentCustomer);
                }
                catch (InvalidOperationException)
                {
                    _modelLayer.addCustomer(_vm.CurrentCustomer);
                }
            }
            catch (InvalidItemProperties)
            {
                MessageBox.Show("Item cannot be created because it has incorrect properties.");
            }
        }
        public override bool CanExecute(object parameter)
        {
            return _vm.CurrentCustomer != null;
        }
    }
}
