using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic.Customers
{
    internal class CustomerValidator
    {
        private IDataLayer _storage;

        public CustomerValidator(IDataLayer storage)
        {
            _storage = storage;
        }
        public bool haveSameProperties(ICustomer? a, ICustomer? b)
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
            bool addressOk = bothNullOrEqual(a.Address, b.Address);
            bool contactInfoOk = bothNullOrEqual(a.ContactInfo, b.ContactInfo);

            return firstNameOk && lastNameOk && addressOk && contactInfoOk;
        }

        internal bool alreadyInStorage(ICustomer customer)
        {
            return _storage.Customers.get(c => haveSameProperties(customer, c)) != null;
        }

        internal bool incorrectProperties(ICustomer customer)
        {
            if (customer.FirstName == null || customer.FirstName == string.Empty) return true;
            if (customer.LastName == null || customer.LastName == string.Empty) return true;
            if (customer.Address == null || customer.Address == string.Empty) return true;
            return false;
        }
    }
}
