using Bookshop.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.ViewModel;
using Bookshop.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.ViewModel
{
    public class InvoicesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IInvoice> _invoices;
        private IInvoice? _currentInvoice;
        private IModelLayer _modelLayer;

        public IEnumerable<IInvoice> Invoices => _invoices;

        public IInvoice? CurrentInvoice
        {
            get => _currentInvoice;
            set
            {
                _currentInvoice = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public InvoicesViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _invoices = _modelLayer.getInvoicesObservable();
        }
    }
}
