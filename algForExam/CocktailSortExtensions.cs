namespace algForExam
{
    public static class CocktailSortExtensions
    {
        public static IList<T> CocktailSort<T>(this IList<T> collection) where T : IComparable
        {
            for (var i = 0; i < collection.Count; i++)
            {
                var needSort = false;
                for (var j = i; j < collection.Count - 1 - i; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                        needSort = true;
                    }
                }

                for (var j = collection.Count - 2 - i; j > i; j--)
                {
                    if (collection[j - 1].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j - 1]) = (collection[j - 1], collection[j]);
                        needSort = true;
                    }
                }

                if (!needSort) return collection;
            }

            return collection;
        }

        public static IList<T> CocktailSort<T>(this IList<T> collection, IComparer<T> comparer) where T : IComparable
        {
            for (var i = 0; i < collection.Count; i++)
            {
                var needSort = false;
                for (var j = i; j < collection.Count - 1 - i; j++)
                {
                    if (comparer.Compare(collection[j], collection[j + 1]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                        needSort = true;
                    }
                }

                for (var j = collection.Count - 2 - i; j > i; j--)
                {
                    if (comparer.Compare(collection[j - 1], collection[j]) > 0) // Сортировка по возрастанию
                    {
                        (collection[j], collection[j - 1]) = (collection[j - 1], collection[j]);
                        needSort = true;
                    }
                }

                if (!needSort) return collection;
            }

            return collection;
        }
    }
}
