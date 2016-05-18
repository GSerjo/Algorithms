using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class QueueNodeOf<T>
    {
        private Node _head;
        private Node _tail;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _head.Value;
            _head = _head.Next;
            Count--;
            return result;
        }

        public void Enqueue(T value)
        {
            Node oldTail = _tail;
            _tail = new Node { Value = value };
            if (IsEmpty)
            {
                _head = _tail;
            }
            else
            {
                oldTail.Next = _tail;
            }
            Count++;
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
