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
            if (newCount > 0)
                _counter[element] = newCount;
            else _counter.Remove(element);
        }

        public int get(E element)
        {
            if (!_counter.ContainsKey(element)) return 0;
            return _counter[element];
        }

    }
}
