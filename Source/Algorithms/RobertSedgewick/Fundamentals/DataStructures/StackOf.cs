using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class StackOf<T>
    {
        private Node _first;

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return _first == null; }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _first.Value;
            _first = _first.Next;
            Count--;
            return result;
        }

        public void Push(T value)
        {
            Node oldFirst = _first;
            _first = new Node { Value = value, Next = oldFirst };
            Count++;
        }


        private sealed class Node
        {
            public Node Next;
            public T Value;
        }
    }
}
