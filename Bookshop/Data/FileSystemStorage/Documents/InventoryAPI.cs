using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class InventoryAPI : IInventoryAPI
    {
        Counter<ID> _document;
        string filePath;
        public InventoryAPI(string filePath)
        {
            this.filePath = filePath; 
            _document = new Counter<ID>();
            try
            {
                _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);
            }
            catch (FileNotFoundException)
            {
                Serialization.WriteToXmlFile(filePath, _document);
            }
            catch (DirectoryNotFoundException)
            {
                Serialization.WriteToXmlFile(filePath, _document);
            }
        }

        public void addOne(ID item)
        {
            _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);
            _document.Add(item);
            Serialization.WriteToXmlFile(filePath, _document);
        }
        public void add(ID item, int numberToSupply)
        {
            _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);

            int count = _document.Get(i => i.Equals(item));
            int newCount = count + numberToSupply;

            _document.Set(item, newCount);

            Serialization.WriteToXmlFile(filePath, _document);
        }

        public int count(ID item)
        {
            _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);
            return _document.Get(i => i.Equals(item));
        }

        public bool remove(ID item, int numberToBuy)
        {
            _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);

            bool success = true;
            int count = _document.Get(i => i.Equals(item));
            if (numberToBuy > count) success = false;

            int newCount = count - numberToBuy;
            _document.Set(item, newCount);

            Serialization.WriteToXmlFile(filePath, _document);
            return success;
        }

        public bool removeOne(ID id)
        {
            try
            {
                _document = Serialization.ReadFromXmlFile<Counter<ID>>(filePath);
                _document.RemoveOne(id);
                Serialization.WriteToXmlFile(filePath, _document);
            } 
            catch (KeyNotFoundException)
            { 
                return false;
            }
            return true;
        }
    }
}
