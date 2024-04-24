using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class CustomersAPI : IStorageAPI<ICustomer>
    {
        int nextId;
        protected List<Customer> _document;
        protected readonly string filePath;

        public CustomersAPI(string filePath)
        {
            this.filePath = filePath;
            _document = new List<Customer>();
            try
            {
                _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            }
            catch (Exception)
            {
                Serialization.WriteToXmlFile(filePath, _document);
                nextId = 0;
            }
            //Serialization.WriteToXmlFile(filePath, new List<T>()); // clear database on every start
        }

        public ID add(ICustomer item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);
            _document.Add(new Customer(item.Id, item.FirstName, item.LastName, item.Address, item.ContactInfo));
            Serialization.WriteToXmlFile(filePath, _document);

            return id;
        }

        public ICustomer? get(Predicate<ICustomer> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);
            return _document.Find(query);
        }

        public List<ICustomer> getAll(Predicate<ICustomer> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);

            return [.. _document.FindAll(query)];
        }

        public bool remove(ID id)
        {
            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);
            foreach (Customer item in _document)
            {
                if (item.Id.Equals(id))
                {
                    _document.Remove(item);
                    Serialization.WriteToXmlFile(filePath, _document);
                    return true;
                }
            }
            return false;
        }

        public void update(ICustomer newCustomer)
        {
            _document = Serialization.ReadFromXmlFile<List<Customer>>(filePath);

            ICustomer customerToUpdate = get(c => c.Id.Equals(newCustomer.Id));
            customerToUpdate.FirstName = newCustomer.FirstName;
            customerToUpdate.LastName = newCustomer.LastName;
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.ContactInfo = newCustomer.ContactInfo;

            Serialization.WriteToXmlFile(filePath, _document);
        }

    }
}
