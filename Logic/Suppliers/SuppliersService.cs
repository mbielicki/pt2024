using Data.API;
using Logic.Model;

namespace Logic.Suppliers
{
    public class SuppliersService : IService<Model.Entities.ISupplier>
    {
        private IDataLayer _dataLayer;
        private SupplierValidator _validator;
        public SuppliersService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _validator = new SupplierValidator(dataLayer);
        }

        public int add(Model.Entities.ISupplier supplier)
        {
            if (_validator.incorrectProperties(supplier.ToData()))
                throw new InvalidItemProperties();

            if (_validator.alreadyInStorage(supplier.ToData()))
                throw new ItemAlreadyExists();

            return _dataLayer.Suppliers.add(supplier.ToData());
        }

        public Model.Entities.ISupplier get(int supplierId)
        {
            Data.Model.Entities.ISupplier? result = _dataLayer.Suppliers.get(s => s.Id.Equals(supplierId));
            if (result == null)
                throw new ItemIdNotFound();
            return result.ToLogic();
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

        public void update(Model.Entities.ISupplier newSupplier)
        {
            if (_validator.incorrectProperties(newSupplier.ToData()))
                throw new InvalidItemProperties();
            try
            {
                _dataLayer.Suppliers.update(newSupplier.ToData());
            }
            catch (NullReferenceException)
            {
                throw new ItemIdNotFound();
            }
        }
    }
}
