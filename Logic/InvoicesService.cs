using Data.API;
using Data.Model.Entities;
using Logic.Model;

namespace Logic
{
    public class InvoicesService : IEventService<Model.Entities.IInvoice>
    {
        IDataLayer _dataLayer;
        public InvoicesService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public Model.Entities.IInvoice get(int id)
        {
            IInvoice? result = _dataLayer.Invoices.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result.ToLogic();
        }

        public List<int> getIds()
        {
            return _dataLayer.Invoices.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }
    }
}
