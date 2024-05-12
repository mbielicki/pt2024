using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.FileSystemStorage.Documents
{
    internal class SuppliersAPI : IStorageAPI<ISupplier>
    {
        int nextId;
        protected List<Supplier> _document;
        protected readonly string filePath;

        public SuppliersAPI(string filePath)
        {
            this.filePath = filePath;
            _document = new List<Supplier>();
            try
            {
                _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            }
            catch (Exception)
            {
                Serialization.WriteToXmlFile(filePath, _document);
                nextId = 0;
            }
            //Serialization.WriteToXmlFile(filePath, new List<T>()); // clear database on every start
        }

        public ID add(ISupplier item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);
            _document.Add(new Supplier(item.Id, item.FirstName, item.LastName,
                item.CompanyName, item.Address, item.ContactInfo));
            Serialization.WriteToXmlFile(filePath, _document);

            return id;
        }

        public ISupplier? get(Predicate<ISupplier> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);
            return _document.Find(query);
        }

        public List<ISupplier> getAll(Predicate<ISupplier> query)
        {
            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);

            return [.. _document.FindAll(query)];
        }

        public bool remove(ID id)
        {
            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);
            foreach (Supplier item in _document)
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

        public void update(ISupplier newSupplier)
        {
            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);

            ISupplier supplierToUpdate = get(s => s.Id.Equals(newSupplier.Id));
            supplierToUpdate.FirstName = newSupplier.FirstName;
            supplierToUpdate.LastName = newSupplier.LastName;
            supplierToUpdate.Address = newSupplier.Address;
            supplierToUpdate.ContactInfo = newSupplier.ContactInfo;

            Serialization.WriteToXmlFile(filePath, _document);
        }

    }
}
