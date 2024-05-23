
namespace Logic.Model
{
    public static class Converter
    {
        public static Data.Model.Entities.IBook ToData(this Entities.IBook entity)
        {
            return new Data.Model.Entities.SimpleBook()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                Price = entity.Price
            };
        }
        public static Entities.IBook ToLogic(this Data.Model.Entities.IBook entity)
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
        public static Data.Model.Entities.ICustomer ToData(this Entities.ICustomer entity)
        {
            return new Data.Model.Entities.SimpleCustomer()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Entities.ICustomer ToLogic(this Data.Model.Entities.ICustomer entity)
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
        public static Data.Model.Entities.ISupplier ToData(this Entities.ISupplier entity)
        {
            return new Data.Model.Entities.SimpleSupplier()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyName = entity.CompanyName,
                Address = entity.Address,
                ContactInfo = entity.ContactInfo
            };
        }
        public static Entities.ISupplier ToLogic(this Data.Model.Entities.ISupplier entity)
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
        public static Entities.ISupply ToLogic(this Data.Model.Entities.ISupply entity)
        {
            return new Entities.SimpleSupply()
            {
                Id = entity.Id,
                Books = entity.Books.ToLogic(),
                Supplier = entity.Supplier.ToLogic(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Data.Model.Entities.ISupply ToData(this Entities.ISupply entity)
        {
            return new Data.Model.Entities.SimpleSupply()
            {
                Id = entity.Id,
                Books = entity.Books.ToData(),
                Supplier = entity.Supplier.ToData(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Entities.IInvoice ToLogic(this Data.Model.Entities.IInvoice entity)
        {
            return new Entities.SimpleInvoice()
            {
                Id = entity.Id,
                Books = entity.Books.ToLogic(),
                Customer = entity.Customer.ToLogic(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Data.Model.Entities.IInvoice ToData(this Entities.IInvoice entity)
        {
            return new Data.Model.Entities.SimpleInvoice()
            {
                Id = entity.Id,
                Books = entity.Books.ToData(),
                Customer = entity.Customer.ToData(),
                Price = entity.Price,
                DateTime = entity.DateTime
            };
        }
        public static Counter<Entities.IBook> ToLogic(this Data.Model.Counter<Data.Model.Entities.IBook> entity)
        {
            Counter<Entities.IBook> counter = new Counter<Entities.IBook>();

            foreach (var item in entity)
            {
                counter.Set(item.Key.ToLogic(), item.Value);
            }
            return counter;
        }
        public static Data.Model.Counter<Data.Model.Entities.IBook> ToData(this Counter<Entities.IBook> entity)
        {
            Data.Model.Counter<Data.Model.Entities.IBook> counter = new();

            foreach (var item in entity)
            {
                counter.Set(item.Key.ToData(), item.Value);
            }
            return counter;
        }
    }
}
