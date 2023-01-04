namespace algForExam
{
    public static class QuickSortExtensions
    {
        public enum PartitionType
        {
            Lomuto, Hoare
        }

        private static IList<T> QuickSortLomuto<T>(this IList<T> collection, int left, int right) where T : IComparable
        {
            if (left >= right) return collection;
            var pivot = collection.PartitionLomuto(left, right);
            QuickSortLomuto(collection, left, pivot - 1);
            QuickSortLomuto(collection, pivot + 1, right);

            return collection;
        }

        private static int PartitionLomuto<T>(this IList<T> collection, int left, int right) where T : IComparable
        {
            var pivot = left - 1; // В качестве опорного элемента выбирается самый левый элемент
            for (var i = left; i < right; i++)
            {
                if (collection[right].CompareTo(collection[i]) > 0) // Сортировка по возрастанию
                {
                    pivot++;
                    (collection[pivot], collection[i]) = (collection[i], collection[pivot]);
                }
            }

            pivot++;
            (collection[pivot], collection[right]) = (collection[right], collection[pivot]);

            return pivot;
        }

        public static IList<T> QuickSort<T>(this IList<T> collection, PartitionType partitionType = PartitionType.Hoare) where T : IComparable
        {
            return partitionType switch
            {
                PartitionType.Lomuto => collection.QuickSortLomuto(0, collection.Count - 1),
                PartitionType.Hoare => collection.QuickSortHoare(0, collection.Count - 1),
                _ => throw new ArgumentException("Доступны схема разделения Ломуто и Хоаре.")
            };
        }

        private static IList<T> QuickSortHoare<T>(this IList<T> collection, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                var pivot = collection.PartitionHoare(left, right);
                collection.QuickSortHoare(left, pivot);
                collection.QuickSortHoare(pivot + 1, right);
            }

            return collection;
        }

        private static int PartitionHoare<T>(this IList<T> collection, int left, int right) where T : IComparable
        {
            var pivot = collection[left]; // В качестве опорного элемента выбирается самый левый элемент

            var i = left - 1;
            var j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (pivot.CompareTo(collection[i]) > 0); // Сортировка по возрастанию

                do
                {
                    j--;
                } while (collection[j].CompareTo(pivot) > 0); // Сортировка по возрастанию

                if (i >= j)
                {
                    return j;
                }

                (collection[i], collection[j]) = (collection[j], collection[i]);
            }
        }
    }
}
