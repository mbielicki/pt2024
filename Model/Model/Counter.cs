using System.Collections;

namespace Data.Model
{
    public class Counter<E> : IEnumerable<KeyValuePair<E, int>>
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

        public IEnumerator<KeyValuePair<E, int>> GetEnumerator()
        {
            return new CounterEnum(_counter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
                return position < _dict.Length;
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
