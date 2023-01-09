using System.Collections;

namespace algForExam
{
    public class Stack<T> : IReadOnlyCollection<T>
    {
        private class Node<T>
        {
            public T Value { get; }

            public Node<T> Top { get; init; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node<T>? _top;

        public int Count { get; private set; }

        public void Push(T element)
        {
            var newNode = new Node<T>(element)
            {
                Top = _top
            };
            _top = newNode;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Стек пуст, нельзя извлечь элемент.");

            var elem = _top.Value;
            _top = _top.Top;
            Count--;
            return elem;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Стек пуст, нельзя получить элемент.");

            return _top.Value;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _top;
            while (node != null)
            {
                yield return node.Value;
                node = node.Top;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
