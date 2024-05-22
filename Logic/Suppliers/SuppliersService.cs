using Data.API;
using Data.Model;
using Data.Model.Entities;
using Logic;

namespace Logic.Suppliers
{
    public class SuppliersService : IService<ISupplier>
    {
        private IDataLayer _dataLayer;
        private SupplierValidator _validator;
        public SuppliersService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new SupplierValidator(dataLayer);
        }

        public int add(ISupplier supplier)
        {
            if (_validator.incorrectProperties(supplier))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(supplier))
                throw new ItemAlreadyExists();

            return _dataLayer.Suppliers.add(supplier);
        }

        public ISupplier get(int supplierId)
        {
            ISupplier? result = _dataLayer.Suppliers.get(s => s.Id.Equals(supplierId));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _dataLayer.Suppliers.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }

        public void remove(int supplierId)
        {
            if (_dataLayer.Suppliers.remove(supplierId)) return;
            throw new ItemIdNotFound();
        }

        public void update(ISupplier newSupplier)
        {
            if (_validator.incorrectProperties(newSupplier))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Suppliers.update(newSupplier);
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
