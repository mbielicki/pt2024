using Bookshop.Model.Data.API;
using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using static Bookshop.Model.Data.FileSystemStorage.Serialization;

namespace Bookshop.Model.Data.FileSystemStorage.Documents
{
    internal class SupplyRegisterAPI : IStorageAPI<ISupplyRegisterEntry>
    {
        int nextId;
        List<SupplyRegisterEntry> _document;
        readonly string filePath;
        CatalogueAPI catalogue;
        SuppliersAPI suppliers;

        public SupplyRegisterAPI(string filePath, CatalogueAPI catalogue, SuppliersAPI suppliers)
        {
            this.filePath = filePath;
            this.catalogue = catalogue;
            this.suppliers = suppliers;
            _document = new List<SupplyRegisterEntry>();
            try
            {
                _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            }
            catch (Exception)
            {
                _document.toXml(filePath);
                nextId = 0;
            }
        }

        public ID add(ISupplyRegisterEntry item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);
            _document.Add(new SupplyRegisterEntry(item.Id, item.Books, item.Supplier, item.Price, item.DateTime));
            _document.toXml(filePath);

            return id;
        }

        public ISupplyRegisterEntry? get(Predicate<ISupplyRegisterEntry> query)
        {
            _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);
            return _document.Find(query);
        }

        public List<ISupplyRegisterEntry> getAll(Predicate<ISupplyRegisterEntry> query)
        {
            _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);

            return [.. _document.FindAll(query)];
        }

        public bool remove(ID id)
        {
            _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);
            foreach (SupplyRegisterEntry item in _document)
            {
                if (item.Id.Equals(id))
                {
                    _document.Remove(item);
                    _document.toXml(filePath);
                    return true;
                }
            }
            return false;
        }

        public void update(ISupplyRegisterEntry newEntry)
        {
            _document = ReadSupplyEntriesXml(filePath, catalogue, suppliers);

            ISupplyRegisterEntry entryToUpdate = get(i => i.Id.Equals(newEntry.Id));
            entryToUpdate.Books = newEntry.Books;
            entryToUpdate.Supplier = newEntry.Supplier;
            entryToUpdate.Price = newEntry.Price;
            entryToUpdate.DateTime = newEntry.DateTime;

            _document.toXml(filePath);
        }

    }
}
