using System;
using System.Text;

namespace Algorithms.DataStructures
{
    public sealed class DoublyLinkedListStructure<T>
    {
        private readonly Node _head = new Node();
        private readonly Node _tail = new Node();
        public int Count { get; private set; }

        public DoublyLinkedListStructure<T> AddFirst(T value)
        {
            Node next = _head.Next;
            var node = new Node { Value = value, Next = next };

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
            Node node = _head.Next;
            while (node != null)
            {
                builder.AppendFormat("{0};", node.Value);
                node = node.Next;
            }
            builder.Append("}");
            return builder.ToString();
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }
        }
    }
}
