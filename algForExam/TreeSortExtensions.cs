namespace algForExam
{
    public static class TreeSortExtensions
    {
        public class Node<T> where T : IComparable
        {
            public T Value { get; set; }

            public Node<T>? Left { get; private set; }

            public Node<T>? Right { get; private set; }

            public Node(T value)
            {
                Value = value;
            }

            public void Insert(T value)
            {
                if (Value.CompareTo(value) > 0) // Сортировка по возрастанию
                {
                    if (Left == null)
                    {
                        Left = new Node<T>(value);
                    }
                    else
                    {
                        Left.Insert(value);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new Node<T>(value);
                    }
                    else
                    {
                        Right.Insert(value);
                    }
                }
            }

            public IList<T> ToList(IList<T>? collection = null)
            {
                var index = 0;
                return ToList(ref index, collection);
            }

            private IList<T> ToList(ref int index, IList<T>? collection = null)
            {
                collection ??= new List<T>();

                Left?.ToList(ref index, collection);

                collection[index++] = Value;

                Right?.ToList(ref index, collection);

                return collection;
            }
        }

        public static IList<T> TreeSort<T>(this IList<T> collection) where T : IComparable
        {
            if (collection.Count > 0)
            {
                var node = new Node<T>(collection[0]);
                for (var i = 1; i < collection.Count; i++)
                {
                    node.Insert(collection[i]);
                }

                node.ToList(collection);
            }

            return collection;
        }
    }
}
