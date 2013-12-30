using System.Text;

namespace Algorithms.DataStructures
{
    public sealed class LinkedListStructure<T>
    {
        private readonly Node<T> _head = new Node<T>();
        private readonly Node<T> _tail = new Node<T>();

        public LinkedListStructure()
        {
            _head = _tail;
        }

        public int Count { get; private set; }

        public LinkedListStructure<T> AddFirst(T value)
        {
            var node = new Node<T> { Value = value, Next = _head.Next };
            _head.Next = node;
            Count++;
            return this;
        }

        public LinkedListStructure<T> AddLast(T value)
        {
            var node = new Node<T> { Value = value };
            Node<T> previousNode = _tail.Next;
            previousNode.Next = node;
            _tail.Next = node;
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
            public TValue Value { get; set; }
        }
    }
}
