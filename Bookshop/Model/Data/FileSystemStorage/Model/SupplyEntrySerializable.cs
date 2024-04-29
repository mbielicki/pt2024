using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;

namespace Bookshop.Model.Data.FileSystemStorage.Model
{
    public class SupplyEntrySerializable : IXmlSerializable
    {
        public ID? Id { get; set; }
        public ID Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<ID> Books { get; set; }
        public SupplyEntrySerializable(ISupplyRegisterEntry entry)
        {
            Id = entry.Id;
            Books = booksToIds(entry.Books);
            Supplier = entry.Supplier.Id;
            Price = entry.Price;
            DateTime = entry.DateTime;
        }

        public SupplyRegisterEntry toSupplyEntry(IStorageAPI<IBook> catalogue, IStorageAPI<ISupplier> suppliers)
        {
            SupplyRegisterEntry newEntry = new SupplyRegisterEntry();
            newEntry.Id = Id;
            newEntry.Supplier = suppliers.get(s => s.Id.Equals(Supplier));
            newEntry.Price = Price;
            newEntry.DateTime = DateTime;
            newEntry.Books = new Counter<IBook>();

            foreach (var idToNumber in Books)
            {
                ID id = idToNumber.Key;
                int num = idToNumber.Value;
                newEntry.Books.Set(catalogue.get(b => b.Id.Equals(id)), num);
            }
            return newEntry;
        }

        private Counter<ID> booksToIds(Counter<IBook> books)
        {
            Counter<ID> result = new Counter<ID>();
            foreach (var bookToNumber in books)
            {
                ID id = bookToNumber.Key.Id;
                int number = bookToNumber.Value;
                result.Set(id, number);
            }
            return result;
        }

        public SupplyEntrySerializable() { }

        public void ReadBooksXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            Books = new Counter<ID>();
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
                            Books.Set(identifier, count);

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

        public void WriteBooksXml(XmlWriter writer)
        {
            writer.WriteStartElement("Counter");
            foreach (var pair in Books)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("id", pair.Key.ToString());
                writer.WriteString(pair.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Id");
            writer.WriteString(Id.Value.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Supplier");
            writer.WriteString(Supplier.Value.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Price");
            writer.WriteString(Price.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("DateTime");
            writer.WriteString(DateTime.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Books");
            WriteBooksXml(writer);
            writer.WriteEndElement();
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            string inElement = "";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        inElement = reader.Name;
                        if (inElement == "Books")
                            ReadBooksXml(reader);
                        break;
                    case XmlNodeType.Text:
                        if (inElement == "Id")
                            Id = new ID(int.Parse(reader.Value));
                        else if (inElement == "Supplier")
                            Supplier = new ID(int.Parse(reader.Value));
                        else if (inElement == "Price")
                            Price = double.Parse(reader.Value);
                        else if (inElement == "DateTime")
                            DateTime = DateTime.Parse(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        inElement = "";
                        break;
                    default:
                        break;
                }
            }
        }
        public XmlSchema? GetSchema()
        {
            return null;
        }

    }
}
