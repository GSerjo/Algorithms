using System.Text;

namespace Algorithms.DataStructures
{
    public sealed class DoublyLinkedListStructure<T>
    {
        private readonly Node<T> _head = new Node<T>();
        private readonly Node<T> _tail = new Node<T>();
        public int Count { get; private set; }

        public DoublyLinkedListStructure<T> AddFirst(T value)
        {
            Node<T> next = _head.Next;
            var node = new Node<T> { Value = value, Next = next };

            Count++;
            if (Count == 1)
            {
                _tail.Previous = node;
            }
            else
            {
                next.Previous = node;
            }
            _head.Next = node;
            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("{");
            Node<T> node = _head.Next;
            while (node != null)
            {
                builder.AppendFormat("{0};", node.Value);
                node = node.Next;
            }
            builder.Append("}");
            return builder.ToString();
        }

        private sealed class Node<TValue>
        {
            public Node<TValue> Next { get; set; }
            public Node<TValue> Previous { get; set; }
            public TValue Value { get; set; }
        }
    }
}
