using Bookshop.Model.Data.API;
using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.Model;
using System.IO;
using static Bookshop.Model.Data.FileSystemStorage.Serialization;

namespace Bookshop.Model.Data.FileSystemStorage.Documents
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
                _document = ReadCounterIdXml(filePath);
            }
            catch (FileNotFoundException)
            {
                _document.toXml(filePath);
            }
            catch (DirectoryNotFoundException)
            {
                _document.toXml(filePath);
            }
        }

        public void addOne(ID item)
        {
            _document = ReadCounterIdXml(filePath);
            _document.Add(item);
            _document.toXml(filePath);
        }
        public void add(ID item, int numberToSupply)
        {
            _document = ReadCounterIdXml(filePath);

            int count = _document.Get(i => i.Equals(item));
            int newCount = count + numberToSupply;

            _document.Set(item, newCount);

            _document.toXml(filePath);
        }

        public int count(ID item)
        {
            _document = ReadCounterIdXml(filePath);
            return _document.Get(i => i.Equals(item));
        }

        public bool remove(ID item, int numberToBuy)
        {
            _document = ReadCounterIdXml(filePath);

            bool success = true;
            int count = _document.Get(i => i.Equals(item));
            if (numberToBuy > count) success = false;

            int newCount = count - numberToBuy;
            _document.Set(item, newCount);

            _document.toXml(filePath);
            return success;
        }

        public bool removeOne(ID id)
        {
            try
            {
                _document = ReadCounterIdXml(filePath);
                _document.RemoveOne(id);
                _document.toXml(filePath);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return true;
        }
    }
}
