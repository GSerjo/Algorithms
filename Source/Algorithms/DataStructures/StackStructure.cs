using System;

namespace Algorithms.DataStructures
{
    public sealed class StackStructure<T>
    {
        private readonly Node<T> _head = new Node<T>();

        public T Pop()
        {
            Node<T> node = _head.Next;
            if (node == null)
            {
                throw new IndexOutOfRangeException();
            }
            _head.Next = node.Next;
            return node.Value;
        }

        public void Push(T data)
        {
            var node = new Node<T> { Value = data, Next = _head.Next };
            _head.Next = node;
        }

        private sealed class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Next { get; set; }
        }
    }
}
