using Data.API;
using Data.Model.Entities;

namespace Logic.Suppliers
{
    internal class SupplierValidator
    {
        private IDataLayer _dataLayer;

        public SupplierValidator(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public bool haveSameProperties(ISupplier? a, ISupplier? b)
        {
            if (a == null || b == null) return false;

            bool bothNullOrEqual(object? a, object? b)
            {
                if (a == null && b == null) return true;
                if (a == null && b != null) return false;
                if (a != null && b == null) return false;
                return a.Equals(b);
            }

            bool firstNameOk = bothNullOrEqual(a.FirstName, b.FirstName);
            bool lastNameOk = bothNullOrEqual(a.LastName, b.LastName);
            bool companyNameOk = bothNullOrEqual(a.CompanyName, b.CompanyName);
            bool addressOk = bothNullOrEqual(a.Address, b.Address);
            bool contactInfoOk = bothNullOrEqual(a.ContactInfo, b.ContactInfo);

            return firstNameOk && lastNameOk && companyNameOk && addressOk && contactInfoOk;
        }

        internal bool alreadyInStorage(ISupplier supplier)
        {
            return _dataLayer.Suppliers.get(s => haveSameProperties(supplier, s)) != null;
        }

        internal bool incorrectProperties(ISupplier supplier)
        {
            if (supplier.FirstName == null || supplier.FirstName == string.Empty) return true;
            if (supplier.LastName == null || supplier.LastName == string.Empty) return true;
            if (supplier.CompanyName == null || supplier.CompanyName == string.Empty) return true;
            if (supplier.Address == null || supplier.Address == string.Empty) return true;
            if (supplier.ContactInfo == null || supplier.ContactInfo == string.Empty) return true;
            return false;
        }
    }
}
