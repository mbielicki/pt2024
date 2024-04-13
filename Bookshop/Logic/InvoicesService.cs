using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    public class InvoicesService
    {
        IBookshopStorage _storage;
        public InvoicesService(IBookshopStorage storage) { _storage = storage;  }
        public Invoice get(ID id)
        {
            Invoice? result = _storage.Invoices.get(i => i.Id == id);
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
