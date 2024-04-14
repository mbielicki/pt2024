using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Logic.Suppliers
{
    internal class SupplierValidator
    {
        private IBookshopStorage _storage;

        public SupplierValidator(IBookshopStorage storage)
        {
            _storage = storage;
        }
        public bool haveSameProperties(Supplier? a, Supplier? b)
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

        internal bool alreadyInStorage(Supplier supplier)
        {
            return _storage.Suppliers.get(s => haveSameProperties(supplier, s)) != null;
        }

        internal bool incorrectProperties(Supplier supplier)
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
