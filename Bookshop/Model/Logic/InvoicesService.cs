using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;

namespace Bookshop.Model.Logic
{
    public class InvoicesService
    {
        IBookshopStorage _storage;
        public InvoicesService(IBookshopStorage storage) { _storage = storage; }
        public IInvoice get(ID id)
        {
            IInvoice? result = _storage.Invoices.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<ID> getIds()
        {
            return _storage.Invoices.getAll((i) => true).ConvertAll(i => i.Id);

        }
    }
}
