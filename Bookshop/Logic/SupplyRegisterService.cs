using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic
{
    public class SupplyRegisterService
    {
        IBookshopStorage _storage;
        public SupplyRegisterService(IBookshopStorage storage) { _storage = storage;  }
        public SupplyRegisterEntry get(ID id)
        {
            SupplyRegisterEntry? result = _storage.SupplyRegister.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<ID> getIds()
        {
            return _storage.SupplyRegister.getAll((i) => true).ConvertAll(i => i.Id);

        }
    }
}
