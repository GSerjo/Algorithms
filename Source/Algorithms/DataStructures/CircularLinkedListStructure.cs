using System;
using System.Text;

namespace Algorithms.DataStructures
{
    public class CircularLinkedListStructure<T>
    {
        private Node _tail;
        public int Count { get; private set; }

        public CircularLinkedListStructure<T> AddFirst(T value)
        {
            var node = new Node { Value = value };
            if (_tail == null)
            {
                _tail = node;
                _tail.Next = node;
            }
            else
            {
                node.Next = _tail.Next;
                _tail.Next = node;
            }
            Count++;
            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("{");
            Node node = _tail.Next;
            do
            {
                builder.AppendFormat("{0};", node.Value);
                node = node.Next;
            }
            while (node != _tail.Next);
            builder.Append("}");
            return builder.ToString();
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
