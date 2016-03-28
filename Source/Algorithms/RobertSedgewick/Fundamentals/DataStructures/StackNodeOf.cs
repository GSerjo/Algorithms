using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class StackNodeOf<T>
    {
        private Node _first;
        public bool IsEmpty => _first == null;

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _first.Value;
            _first = _first.Next;
            return result;
        }

        public void Push(T value)
        {
            Node old = _first;
            _first = new Node { Value = value, Next = old };
        }


        private sealed class Node
        {
            public Node Next;
            public T Value;
        }
    }
}
