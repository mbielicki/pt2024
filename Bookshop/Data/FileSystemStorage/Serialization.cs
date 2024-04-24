using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage.Model;
using Bookshop.Data.Model;
using System.Xml.Serialization;

namespace Bookshop.Data.FileSystemStorage
{
    public static class Serialization
    {
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static void toXml(this List<Invoice> list, string filePath, bool append = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            TextWriter writer = null;

            List<InvoiceSerializable> listSerializable = new List<InvoiceSerializable>();
            foreach (var invoice in list)
            {
                listSerializable.Add(new InvoiceSerializable(invoice));
            }

            try
            {
                var serializer = new XmlSerializer(typeof(List<InvoiceSerializable>));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, listSerializable);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public static List<Invoice> ReadInvoicesXml(string filePath, IStorageAPI<IBook> catalogue, IStorageAPI<ICustomer> customers)
        {
            TextReader reader = null;
            List<InvoiceSerializable> listSerializable = new List<InvoiceSerializable>();
            try
            {
                var serializer = new XmlSerializer(typeof(List<InvoiceSerializable>));
                reader = new StreamReader(filePath);
                listSerializable = (List<InvoiceSerializable>) serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            List<Invoice> list = new List<Invoice>();

            foreach (var invoiceSerializable in listSerializable)
            {
                list.Add(invoiceSerializable.toInvoice(catalogue, customers));
            }
            return list;
        }

        public static void toXml(this List<SupplyRegisterEntry> list, string filePath, bool append = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            TextWriter writer = null;

            List<SupplyEntrySerializable> listSerializable = new List<SupplyEntrySerializable>();
            foreach (var entry in list)
            {
                listSerializable.Add(new SupplyEntrySerializable(entry));
            }

            try
            {
                var serializer = new XmlSerializer(typeof(List<SupplyEntrySerializable>));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, listSerializable);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public static List<SupplyRegisterEntry> ReadSupplyEntriesXml(string filePath, IStorageAPI<IBook> catalogue, IStorageAPI<ISupplier> suppliers)
        {
            TextReader reader = null;
            List<SupplyEntrySerializable> listSerializable = new List<SupplyEntrySerializable>();
            try
            {
                var serializer = new XmlSerializer(typeof(List<SupplyEntrySerializable>));
                reader = new StreamReader(filePath);
                listSerializable = (List<SupplyEntrySerializable>)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            List<SupplyRegisterEntry> list = new List<SupplyRegisterEntry>();

            foreach (var entrySerializable in listSerializable)
            {
                list.Add(entrySerializable.toSupplyEntry(catalogue, suppliers));
            }
            return list;
        }
    }
}
