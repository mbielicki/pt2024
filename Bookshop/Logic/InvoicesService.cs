using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic
{
    public class InvoicesService : IEventService<IInvoice>
    {
        IDataLayer _dataLayer;
        public InvoicesService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public IInvoice get(int id)
        {
            IInvoice? result = _dataLayer.Invoices.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _dataLayer.Invoices.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }
    }
}
