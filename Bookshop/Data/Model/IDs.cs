using System.Diagnostics.Metrics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bookshop.Data.Model
{
    public interface HasId 
    {
        ID? Id { get; set; }
    }

    public class ID : IXmlSerializable
    {
        public int Value { get; private set; }
        public ID(int value) {
            Value = value;
        }
        public ID()
        {
            Value = 0;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            ID other = (ID)obj;
            return other.Value == Value;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public ID increment() { 
            Value ++;
            return this;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    Value = int.Parse(reader.Value);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Value.ToString());
        }
    }
}
