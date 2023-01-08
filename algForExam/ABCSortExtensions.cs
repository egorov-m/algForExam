namespace algForExam
{
    public static class ABCSortExtensions
    {
        public static IList<string> ABCSort(this IList<string> collection) => collection.ABCSort(0);

        private static IList<string> ABCSort(this IList<string> collection, int rank)
        {
            if (collection.Count < 2) return collection;

            var table = new System.Collections.Generic.Dictionary<char, IList<string>>(); // key - символ в позиции rank, список слов с символом key в позиции rank
            var listResult = new List<string>();
            var shortWordsCounter = 0;

            foreach (var str in collection)
            {
                if (rank < str.Length)
                {
                    if (table.ContainsKey(str[rank]))
                    {
                        table[str[rank]].Add(str);
                    }
                    else
                    {
                        table.Add(str[rank], new List<string> {str});
                    }
                }
                else
                {
                    listResult.Add(str);
                    shortWordsCounter++;
                }
            }

            if (shortWordsCounter == collection.Count) return collection;

            for (var i = 'A'; i <= 'z'; i++)
            {
                if (table.ContainsKey(i))
                {
                    foreach (var str in ABCSort(table[i], rank + 1))
                    {
                        listResult.Add(str);
                    }
                }
            }

            return listResult;
        }
    }
}
