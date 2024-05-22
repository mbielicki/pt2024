
using Data.Model.Entities;

namespace Data.Model
{
    internal static class Converter
    {
        public static Logic.Model.Entities.IBook ToLogic(this Entities.IBook entity)
        {
            return new Logic.Model.Entities.SimpleBook()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                Price = entity.Price
            };
        }
        public static Entities.IBook ToData(this Logic.Model.Entities.IBook entity)
        {
            return new Entities.SimpleBook()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                Price = entity.Price
            };
        }
        public static Logic.Model.Entities.ICustomer ToLogic(this Entities.ICustomer entity)
        {
            return new Logic.Model.Entities.SimpleCustomer()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Entities.ICustomer ToData(this Logic.Model.Entities.ICustomer entity)
        {
            return new Entities.SimpleCustomer()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Logic.Model.Entities.ISupplier ToLogic(this Entities.ISupplier entity)
        {
            return new Logic.Model.Entities.SimpleSupplier()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyName = entity.CompanyName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Entities.ISupplier ToData(this Logic.Model.Entities.ISupplier entity)
        {
            return new Entities.SimpleSupplier()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyName = entity.CompanyName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Entities.ISupply ToData(this Logic.Model.Entities.ISupply entity)
        {
            return new Entities.SimpleSupply()
            {
                Id = entity.Id,
                Books = entity.Books.ToData(),
                Supplier = entity.Supplier.ToData(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Logic.Model.Entities.ISupply ToLogic(this Entities.ISupply entity)
        {
            return new Logic.Model.Entities.SimpleSupply()
            {
                Id = entity.Id,
                Books = entity.Books.ToLogic(),
                Supplier = entity.Supplier.ToLogic(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Entities.IInvoice ToData(this Logic.Model.Entities.IInvoice entity)
        {
            return new Entities.SimpleInvoice()
            {
                Id = entity.Id,
                Books = entity.Books.ToData(),
                Customer = entity.Customer.ToData(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Logic.Model.Entities.IInvoice ToLogic(this Entities.IInvoice entity)
        {
            return new Logic.Model.Entities.SimpleInvoice()
            {
                Id = entity.Id,
                Books = entity.Books.ToLogic(),
                Customer = entity.Customer.ToLogic(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Counter<Entities.IBook> ToData(this Logic.Model.Counter<Logic.Model.Entities.IBook> entity)
        {
            Counter<Entities.IBook> counter = new Counter<Entities.IBook>();

            foreach (var item in entity)
            {
                counter.Set(item.Key.ToData(), item.Value);
            }
            return counter;
        }
        public static Logic.Model.Counter<Logic.Model.Entities.IBook> ToLogic(this Counter<Entities.IBook> entity)
        {
            Logic.Model.Counter<Logic.Model.Entities.IBook> counter = new();

            foreach (var item in entity)
            {
                counter.Set(item.Key.ToLogic(), item.Value);
            }
            return counter;
        }
        public static Logic.Model.Counter<int> ToLogic(this Counter<int> entity)
        {
            Logic.Model.Counter<int> counter = new();

            foreach (var item in entity)
            {
                counter.Set(item.Key, item.Value);
            }
            return counter;
        }
        public static Entities.IInventoryEntry ToData(this Logic.Model.Entities.IInventoryEntry entity)
        {
            return new SimpleInventoryEntry()
            {
                Book = entity.Book.ToData(),
                Count = entity.Count
            };
        }
        public static IEnumerable<IInventoryEntry> ToData(this IEnumerable<Logic.Model.Entities.IInventoryEntry> entity)
        {
            List<IInventoryEntry> list = new List<IInventoryEntry>();
            foreach (var item in entity)
            {
                list.Add(item.ToData());
            }
            return list;
        }
    }
}
