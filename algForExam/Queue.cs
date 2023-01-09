using System.Collections;

namespace algForExam
{
    public class Queue<T> : IReadOnlyCollection<T>
    {
        public class Node<T>
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node<T> Next { get; set; }
        }

        private Node<T>? _head;

        private Node<T>? _tail;

        public int Count { get; private set; }

        public bool IsEmpty() => Count == 0;

        public void Enqueue(T value)
        {
            var node = new Node<T>(value);
            var tempNode = _tail;
            _tail = node;
            if (Count == 0)
            {
                _head = _tail;
            }
            else
            {
                tempNode.Next = _tail;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();
            var output = _head.Value;
            _head = _head.Next;
            Count--;

            return output;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
