using System.Collections;

namespace algForExam
{
    /// <summary> Словарь: хеш-таблица, разрешение коллизий методом цепочек </summary>
    /// <typeparam name="TKey"> Тип ключа </typeparam>
    /// <typeparam name="TValue"> Тип значения </typeparam>
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue?>>
    {
        private readonly int _size;

        public double FillFactor => (double)Count / _size;

        public int MaxLengthChain => _items.Max(x => x?.Count ?? 0);

        public int MinLengthChain => _items.Min(x => x?.Count ?? 0);

        public IEnumerable<int> LengthsChains => _items.Select(x => x?.Count ?? 0);

        public int Count { get; private set; }

        private readonly LinkedList<KeyValuePair<TKey, TValue?>>?[] _items;

        public Dictionary(int size = 1000)
        {
            if (!IsSizeCorrect(size)) throw new AggregateException(nameof(size));
            _size = size;
            _items = new LinkedList<KeyValuePair<TKey, TValue?>>[size];
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var item = new KeyValuePair<TKey, TValue?>(key, value);
            Insert(item);
        }

        protected void Insert(KeyValuePair<TKey, TValue?> item)
        {
            var position = GetListPosition(item.Key);
            var linkedList = GetLinkedList(position);

            foreach (var pair in linkedList)
            {
                if (pair.Key != null && pair.Key.Equals(item.Key))
                    throw new ArgumentException("Элемент по указанному ключу уже существует.");
            }

            linkedList.AddLast(item);
            Count++;
        }

        protected bool IsSizeCorrect(int size)
        {
            return size > 0;
        }

        public bool Remove(TKey key)
        {
            var position = GetListPosition(key);
            var linkedList = GetLinkedList(position);
            var itemFound = false;
            var foundItem = default(KeyValuePair<TKey, TValue?>);
            foreach (var item in linkedList)
            {
                if (item.Key != null && item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
                Count--;
            }
            return itemFound;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var position = GetListPosition(key);
            var linkedList = GetLinkedList(position);

            var foundItem = false;
            foreach (var item in linkedList)
            {
                if (item.Key != null && item.Key.Equals(key))
                {
                    foundItem = true;
                    break;
                }
            }

            return foundItem;
        }

        public TValue? GetValue(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var position = GetListPosition(key);
            var linkedList = GetLinkedList(position);
            foreach (var item in linkedList)
            {
                if (item.Key != null && item.Key.Equals(key)) return item.Value;
            }

            return default;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var t = GetValue(key);
            value = t;
            return t != null;
        }

        protected int GetListPosition(TKey key)
        {

            return Math.Abs(key.GetHashCode() % _size); // Метод деления

            // Метод умножения
            // var goldenRatioConst = (Math.Sqrt(5) - 1) / 2;
            // return (int) Math.Abs(_size * (key.GetHashCode() * goldenRatioConst % 1));
        }

        protected LinkedList<KeyValuePair<TKey, TValue?>> GetLinkedList(int position)
        {
            var linkedList = _items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<TKey, TValue?>>();
                _items[position] = linkedList;
            }

            return linkedList;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                for (var i = 0; i < _items.Length; i++)
                {
                    _items[i] = null;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue?>> GetEnumerator()
        {
            foreach (var linkedList in _items)
            {
                if (linkedList != null)
                {
                    foreach (var keyValuePair in linkedList)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
