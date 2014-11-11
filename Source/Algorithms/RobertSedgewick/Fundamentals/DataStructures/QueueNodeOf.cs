using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class QueueNodeOf<T>
    {
        private Node _head;
        private Node _tail;

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _head.Value;
            _head = _head.Next;
            Count--;
            if (IsEmpty)
            {
                _tail = null;
            }
            return result;
        }

        public QueueNodeOf<T> Enqueue(T value)
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
            return this;
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
