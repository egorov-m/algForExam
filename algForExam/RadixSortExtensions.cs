namespace algForExam
{
    public static class RadixSortExtensions
    {
        public static IList<int> RadixSort(this IList<int> collection)
        {
            var maxValue = collection.Max();

            for (var exponent = 1; maxValue / exponent > 0; exponent *= 10)
            {
                collection.CountingSort(exponent);
            }

            return collection;
        }

        public static IList<int> CountingSort(this IList<int> collection, int exponent)
        {
            var outputArr = new int[collection.Count];
            var countArr = new int[10];

            foreach (var item in collection) // Считаем количество вхождений каждого элемента массива
            {
                countArr[(item / exponent) % 10]++;
            }

            for (var i = 1; i < 10; i++) // Сохраняем фактические позиции элементов
            {
                countArr[i] += countArr[i - 1];
            }

            for (var i = collection.Count - 1; i >= 0; i--) // Устанавливаем элементы в отсортированные позиции
            {
                outputArr[countArr[(collection[i] / exponent) % 10] - 1] = collection[i];
                countArr[(collection[i] / exponent) % 10]--;
            }

            for (var i = 0; i < collection.Count; i++) // Копируем элементы в исходный массив
            {
                collection[i] = outputArr[i];
            }

            return collection;
        }
    }
}
