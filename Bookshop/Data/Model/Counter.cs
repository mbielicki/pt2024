using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bookshop.Data.Model
{
    public class Counter<E> : IEnumerable<KeyValuePair<E, int>>, IXmlSerializable where E : HasValue, new()
    {
        private Dictionary<E, int> _counter = new Dictionary<E, int>();

        public void Add(E element)
        {
            if (_counter.ContainsKey(element))
                _counter[element]++;
            else
                _counter.Add(element, 1);
        }
        public void RemoveOne(E element)
        {
            int newCount = _counter[element] - 1;
            Set(element, newCount);
        }

        public int Get(Predicate<E> query)
        {
            foreach (var pair in _counter)
            {
                if (query(pair.Key)) return pair.Value;
            }
            return 0;
        }
        public List<E> Keys => _counter.Keys.ToList();

        public int Count(E element)
        {
            return Get(e => e.Equals(element));
        }
        public void Set(E element, int newCount)
        {
            if (!_counter.ContainsKey(element))
                _counter.Add(element, 0);

            if (newCount > 0)
                _counter[element] = newCount;
            else _counter.Remove(element);
        }

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            Console.WriteLine("start");
            string inElement = "";
            E identifier = new();
            int count = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.WriteLine("Start Element {0}", reader.Name);
                        
                        if (reader.Name == "item")
                        {
                            string id = reader.GetAttribute("id");
                            identifier = new();
                            identifier.Value = int.Parse(id);

                        }
                        inElement = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine("Text Node: {0}",
                                 reader.Value);
                        if (inElement == "item")
                        {
                            count = int.Parse(reader.Value);
                            _counter.Add(identifier, count);

                        }
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine("End Element {0}", reader.Name);
                        if (reader.Name == "item") inElement = "";
                        if (reader.Name == "Counter")
                        {
                            reader.Read();
                            reader.Read();
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Other node {0} with value {1}",
                                        reader.NodeType, reader.Value);
                        break;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Counter");
            foreach (var pair in _counter)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("id", pair.Key.ToString());
                writer.WriteString(pair.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public IEnumerator<KeyValuePair<E, int>> GetEnumerator()
        {
            return new CounterEnum(_counter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }


        private class CounterEnum : IEnumerator<KeyValuePair<E, int>>
        {
            public KeyValuePair<E, int>[] _dict;
            int position = -1;

            public CounterEnum(Dictionary<E, int> dict)
            {
                _dict = dict.ToArray();
            }

            public bool MoveNext()
            {
                position++;
                return (position < _dict.Length);
            }
            public void Reset()
            {
                position = -1;
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }

            public KeyValuePair<E, int> Current
            {
                get
                {
                    try
                    {
                        return _dict[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose() { }

        }
    }
}
