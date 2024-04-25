using Bookshop.Data.Model;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using Bookshop.Data.API;

namespace Bookshop.Data.FileSystemStorage.Model
{
    public class InvoiceSerializable : IXmlSerializable
    {
        public ID? Id { get; set; }
        public ID Customer { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<ID> Books { get; set; }
        public InvoiceSerializable(IInvoice invoice)
        {
            Id = invoice.Id;
            Books = booksToIds(invoice.Books);
            Customer = invoice.Customer.Id;
            Price = invoice.Price;
            DateTime = invoice.DateTime;
        }

        public Invoice toInvoice(IStorageAPI<IBook> catalogue, IStorageAPI<ICustomer> customers)
        {
            Invoice newInvoice = new Invoice();
            newInvoice.Id = Id;
            newInvoice.Customer = customers.get(c => c.Id.Equals(Customer));
            newInvoice.Price = Price;
            newInvoice.DateTime = DateTime;
            newInvoice.Books = new Counter<IBook>();

            foreach (var idToNumber in Books)
            {
                ID id = idToNumber.Key;
                int num = idToNumber.Value;
                newInvoice.Books.Set(catalogue.get(b => b.Id.Equals(id)), num);
            }
            return newInvoice;
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

        public InvoiceSerializable() { }

        public void ReadBooksXml(XmlReader reader)
        {
            Books = new Counter<ID>();
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

            writer.WriteStartElement("Customer");
            writer.WriteString(Customer.Value.ToString());
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
                        else if (inElement == "Customer")
                            Customer = new ID(int.Parse(reader.Value));
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
