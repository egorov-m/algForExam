namespace algForExam
{
    public static class ShellSortExtensions
    {
        public static IList<T> ShellSort<T>(this IList<T> collection) where T : IComparable
        {
            var step = collection.Count / 2;
            while (step > 0)
            {
                step /= 2;
                for (var i = step; i < collection.Count; i++)
                {
                    var j = i;
                    while (j >= step && collection[j - step].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j - step]) = (collection[j - step], collection[j]);
                        j -= step;
                    }
                }
            }

            return collection;
        }

        public static IList<T> ShellSort<T>(this IList<T> collection, IComparer<T> comparer) where T : IComparable
        {
            var step = collection.Count / 2;
            while (step > 0)
            {
                step /= 2;
                for (var i = step; i < collection.Count; i++)
                {
                    var j = i;
                    while (j >= step &&  comparer.Compare(collection[j - step], collection[j]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j - step]) = (collection[j - step], collection[j]);
                        j -= step;
                    }
                }
            }

            return collection;
        }
    }
}
