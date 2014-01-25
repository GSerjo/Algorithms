using System;

namespace Algorithms.DataStructures
{
    public sealed class StackStructure<T>
    {
        private readonly Node _head = new Node();

        public T Pop()
        {
            Node node = _head.Next;
            if (node == null)
            {
                throw new IndexOutOfRangeException();
            }
            _head.Next = node.Next;
            return node.Value;
        }

        public void Push(T data)
        {
            var node = new Node { Value = data, Next = _head.Next };
            _head.Next = node;
        }

        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
