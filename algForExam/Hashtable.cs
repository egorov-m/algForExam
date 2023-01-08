using System.Collections;

namespace algForExam
{
    /// <summary> Хеш-таблица, разрешение коллизий методом открытой адресации </summary>
    /// <typeparam name="TKey"> Тип ключа </typeparam>
    /// <typeparam name="TValue"> Тип значения </typeparam>
    public class Hashtable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue?>>
    {
        private readonly int _size;

        private readonly KeyValuePair<TKey, TValue?>[] _items;

        private readonly bool[] _removed;

        private static readonly Func<Func<object, int, int>, object, int, int, int> LinearHashing =
            (f, key, sizeHashTable, index) => (f(key, sizeHashTable) + index) % sizeHashTable;

        private static readonly Func<Func<object, int, int>, object, int, int, int> QuadraticHashing =
            (f, key, sizeHashTable, index) => (f(key, sizeHashTable) + (int)Math.Pow(index, 2)) % sizeHashTable;

        private static readonly Func<Func<object, int, int>, Func<object, int, int>, object, int, int, int> DoubleHashing =
            (f1, f2, key, sizeHashTable, index) => (f1(key, sizeHashTable) + index * f2(key, sizeHashTable)) % sizeHashTable;

        public int Count { get; private set; }

        public int MaxClusterLength
        {
            get
            {
                var max = 0;
                var current = 0;
                foreach (var item in _items)
                {
                    if (!item.Equals(default(KeyValuePair<TKey, TValue?>)))
                    {
                        current++;
                    }
                    else
                    {
                        max = Math.Max(max, current);
                        current = 0;
                    }
                }

                return Math.Max(max, current);
            }
        }

        public Hashtable(int size = 1000)
        {
            if (!IsSizeCorrect(size)) throw new AggregateException(nameof(size));
            _size = size;
            _items = new KeyValuePair<TKey, TValue?>[size];
            _removed = new bool[_size];
        }

        protected bool CheckOpenSpace()
        {
            var isOpen = false;
            for (var i = 0; i < _size; i++)
            {
                if (_items[i].Equals(default(KeyValuePair<TKey, TValue?>))) isOpen = true;
            }

            return isOpen;
        }

        protected bool IsSizeCorrect(int size)
        {
            return size > 0;
        }

        protected bool CheckUniqueKey(TKey key)
        {
            foreach (var item in _items)
            {
                if (item.Key != null && item.Key.Equals(key)) return false;
            }

            return true;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (!CheckOpenSpace()) throw new ArgumentOutOfRangeException("Хеш-таблица переполнена.");

            if (!CheckUniqueKey(key)) throw new ArgumentException("Элемент по указанному ключу уже существует.");

            Insert(key, value);
        }

        protected void Insert(TKey key, TValue value)
        {
            var index = 0;
            var hashCode = GetHash(key, index);

            while (!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) && !_items[hashCode].Key.Equals(key))
            {
                index++;
                hashCode = GetHash(key, index);
            }

            _items[hashCode] = new KeyValuePair<TKey, TValue?>(key, value);
            _removed[hashCode] = false;
            Count++;
        }

        protected int GetHash(TKey key, int index)
        {
            // Линейный анализ, вспомогательная функция — метод деления.
            return LinearHashing((key, sizeHashTable) => Math.Abs(key.GetHashCode() % sizeHashTable), key, _size, index);
        }

        public TValue? GetValue(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var index = 0;
            var hashCode = GetHash(key, index);

            while ((!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) || _removed[hashCode]) && !_items[hashCode].Key.Equals(key))
            {
                index++;
                hashCode = GetHash(key, index);
            }

            return _items[hashCode].Value;
        }

        public bool Remove(TKey key)
        {
            var index = 0;
            var hashCode = GetHash(key, index);

            while ((!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) || _removed[hashCode]) && !_items[hashCode].Key.Equals(key))
            {
                index++;
                hashCode = GetHash(key, index);
            }

            if (_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)))
            {
                return false;
            }
            else
            {
                _items[hashCode] = default;
                _removed[hashCode] = true;
                Count--;
                return true;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue?>> GetEnumerator()
        {
            foreach (var keyValuePair in _items)
            {
                if (!keyValuePair.Equals(default(KeyValuePair<TKey, TValue?>)))
                {
                    yield return keyValuePair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
