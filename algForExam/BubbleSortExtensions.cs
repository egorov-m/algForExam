namespace algForExam
{
    public static class BubbleSortExtensions
    {
        public static IList<T> BubbleSort<T>(this IList<T> collection) where T : IComparable
        {
            for (var i = 0; i < collection.Count; i++)
            {
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[i]) = (collection[i], collection[j]);
                    }
                }
            }

            return collection;
        }

        public static IList<T> BubbleSort<T>(this IList<T> collection, IComparer<T> comparer) where T : IComparable
        {
            for (var i = 0; i < collection.Count; i++)
            {
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (comparer.Compare(collection[i], collection[j]) > 0)
                    {
                        (collection[j], collection[i]) = (collection[i], collection[j]);
                    }
                }
            }

            return collection;
        }
    }
}
