namespace algForExam
{
    public static class InsertionSortExtensions
    {
        public static IList<T> InsertionSort<T>(this IList<T> collection) where T : IComparable
        {
            for (var i = 1; i < collection.Count; i++)
            {
                var item = collection[i];
                var j = i - 1;

                while (j >= 0 && collection[j].CompareTo(item) > 0) // Сортировка по возрастанию
                {
                    collection[j + 1] = collection[j];
                    j--;
                }

                collection[j + 1] = item;
            }

            return collection;
        }

        public static IList<T> InsertionSort<T>(this IList<T> collection, IComparer<T> comparer) where T : IComparable
        {
            for (var i = 1; i < collection.Count; i++)
            {
                var item = collection[i];
                var j = i - 1;

                while (j >= 0 && comparer.Compare(collection[j], item) > 0) // Сортировка по возрастанию
                {
                    collection[j + 1] = collection[j];
                    j--;
                }

                collection[j + 1] = item;
            }

            return collection;
        }
    }
}
