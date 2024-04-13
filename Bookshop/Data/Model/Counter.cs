using System.Collections;

namespace Bookshop.Data.Model
{
    public class Counter<E>
    {
        private Dictionary<E, int> _counter = new Dictionary<E, int>();

        public void add(E element)
        {
            if (_counter.ContainsKey(element))
                _counter[element]++;
            else
                _counter.Add(element, 1);
        }
        public void remove(E element)
        {
            int newCount = _counter[element] - 1;
            set(element, newCount);
        }

        public int get(Predicate<E> query)
        {
            foreach (var pair in _counter)
            {
                if (query(pair.Key)) return pair.Value;
            }
            return 0;
        }
        public void set(E element, int newCount)
        {
            if (newCount > 0)
                _counter[element] = newCount;
            else _counter.Remove(element);
        }
    }
}
