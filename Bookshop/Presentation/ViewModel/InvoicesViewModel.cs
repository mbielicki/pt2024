using Bookshop.Presentation.Commands;
using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using Bookshop.Presentation.Services;
using Bookshop.Presentation.ViewModel;
using Bookshop.Presentation.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bookshop.Presentation.ViewModel
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
