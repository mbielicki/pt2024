using Data.API;
using Data.Model.Entities;

namespace Logic.Customers
{
    internal class CustomerValidator
    {
        private IDataLayer _dataLayer;

        public CustomerValidator(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
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
            return _dataLayer.Customers.get(c => haveSameProperties(customer, c)) != null;
        }

        internal bool incorrectProperties(ICustomer customer)
        {
            if (customer.FirstName == null || customer.FirstName == string.Empty) return true;
            if (customer.LastName == null || customer.LastName == string.Empty) return true;
            if (customer.Address == null || customer.Address == string.Empty) return true;
            if (customer.ContactInfo == null) customer.ContactInfo = string.Empty;
            return false;
        }
    }
}
