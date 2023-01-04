namespace algForExam
{
    public static class BinarySearchExtensions
    {
        public enum MethodType
        {
            Iterative, Recursive
        }

        public static int BinarySearch<T>(this IList<T> collection, T key, MethodType methodType = MethodType.Iterative) where T : IComparable
        {
            return methodType switch
            {
                MethodType.Iterative => collection.BinarySearchIterative(key, 0, collection.Count - 1),
                MethodType.Recursive => collection.BinarySearchRecursive(key, 0, collection.Count - 1),
                _ => throw new ArgumentException("Доступны итеративный и рекурсивный метод.")
            };
        }

        private static int BinarySearchRecursive<T>(this IList<T> collection, T key, int left, int right) where T : IComparable
        {
            if (right < left) throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");

            var mid = left + (right - left) / 2; // ! вычислять нужно именно так
            var value = collection[mid];

            if (key.Equals(value)) return mid;

            return value.CompareTo(key) > 0 // Коллекция отсортирована по возрастанию
                ? collection.BinarySearchRecursive(key, left, mid - 1)
                : collection.BinarySearchRecursive(key, mid + 1, right);
        }

        private static int BinarySearchRecursive<T>(this IList<T> collection, IComparer<T> comparer, T key, int left, int right) where T : IComparable
        {
            if (right < left) throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");

            var mid = left + (right - left) / 2; // ! вычислять нужно именно так
            var value = collection[mid];

            if (key.Equals(value)) return mid;

            return comparer.Compare(value, key) > 0 // Коллекция отсортирована по возрастанию
                ? collection.BinarySearchRecursive(comparer, key, left, mid - 1)
                : collection.BinarySearchRecursive(comparer, key, mid + 1, right);
        }

        private static int BinarySearchIterative<T>(this IList<T> collection, T key, int left, int right) where T : IComparable
        {
            while (left <= right)
            {
                var mid = left + (right - left) / 2; // ! вычислять нужно именно так
                var value = collection[mid];

                if (key.Equals(value)) return mid;

                if (value.CompareTo(key) > 0) // Коллекция отсортирована по возрастанию
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");
        }

        private static int BinarySearchIterative<T>(this IList<T> collection, IComparer<T> comparer, T key, int left, int right) where T : IComparable
        {
            while (left <= right)
            {
                var mid = left + (right - left) / 2; // ! вычислять нужно именно так
                var value = collection[mid];

                if (key.Equals(value)) return mid;

                if (comparer.Compare(value, key) > 0) // Коллекция отсортирована по возрастанию
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");
        }
    }
}
