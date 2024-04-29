using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage.Model;
using Bookshop.Data.Model;
using System.IO;
using System.Xml;
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

        private static void WriteCounterXml(XmlWriter writer, Counter<ID> counter)
        {
            writer.WriteStartElement("Counter");
            foreach (var pair in counter)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("id", pair.Key.ToString());
                writer.WriteString(pair.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        public static void toXml(this Counter<ID> counter, string filePath, bool append = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            TextWriter writer = null;

            try
            {
                writer = new StreamWriter(filePath, append);
                XmlWriter xmlWriter = XmlWriter.Create(writer);
                xmlWriter.WriteStartDocument();
                WriteCounterXml(xmlWriter, counter);
                xmlWriter.Close();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private static void ReadCounterXml(XmlReader reader, Counter<ID> counter)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            string inElement = "";
            ID identifier = new();
            int count = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "item")
                        {
                            string id = reader.GetAttribute("id");
                            identifier = new();
                            identifier.Value = int.Parse(id);

                        }
                        inElement = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (inElement == "item")
                        {
                            count = int.Parse(reader.Value);
                            counter.Set(identifier, count);

                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "item") inElement = "";
                        if (reader.Name == "Counter")
                        {
                            reader.Read();
                            reader.Read();
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static Counter<ID> ReadCounterIdXml(string filePath)
        {
            TextReader reader = null;
            Counter<ID> counter = new Counter<ID>();
            try
            {
                reader = new StreamReader(filePath);
                XmlReader xmlReader = XmlReader.Create(reader);
                ReadCounterXml(xmlReader, counter);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return counter;
        }
    }
}
