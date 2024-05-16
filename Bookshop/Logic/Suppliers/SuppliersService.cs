using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;

namespace Bookshop.Logic.Suppliers
{
    public class SuppliersService : IService<ISupplier>
    {
        private IBookshopStorage _storage;
        private SupplierValidator _validator;
        public SuppliersService(IBookshopStorage storage)
        {
            _storage = storage;
            _validator = new SupplierValidator(storage);
        }

        public int add(ISupplier supplier)
        {
            if (_validator.incorrectProperties(supplier))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(supplier))
                throw new ItemAlreadyExists();

            return _storage.Suppliers.add(supplier);
        }

        public ISupplier get(int supplierId)
        {
            ISupplier? result = _storage.Suppliers.get(s => s.Id.Equals(supplierId));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _storage.Suppliers.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int supplierId)
        {
            if (_storage.Suppliers.remove(supplierId)) return;
            throw new ItemIdNotFound();
        }

        public void update(ISupplier newSupplier)
        {
            if (_validator.incorrectProperties(newSupplier))
                throw new InvalidItemProperties();
            try
            {
                _storage.Suppliers.update(newSupplier);
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
