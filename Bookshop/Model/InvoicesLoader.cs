using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using System.Collections.ObjectModel;

namespace Bookshop.Model
{
    public class InvoicesLoader
    {
        public static ObservableCollection<IInvoice> loadInvoices()
        {
            ObservableCollection<IInvoice> invoices = new ObservableCollection<IInvoice>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            InvoicesService service = new InvoicesService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                invoices.Add(service.get(id));
            }

            return invoices;
        }
    }
}
