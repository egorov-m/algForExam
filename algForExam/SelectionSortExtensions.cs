namespace algForExam
{
    public static class SelectionSortExtensions
    {
        public static IList<T> SelectionSort<T>(this IList<T> collection) where T : IComparable
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var index = i;
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[index].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
                    {
                        index = j;
                    }
                }

                (collection[index], collection[i]) = (collection[i], collection[index]);
            }

            return collection;
        }

        public static IList<T> SelectionSort<T>(this IList<T> collection, IComparer<T> comparer) where T : IComparable
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var index = i;
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (comparer.Compare(collection[index], collection[j]) > 0)
                    {
                        index = j;
                    }
                }

                (collection[index], collection[i]) = (collection[i], collection[index]);
            }

            return collection;
        }
    }
}
