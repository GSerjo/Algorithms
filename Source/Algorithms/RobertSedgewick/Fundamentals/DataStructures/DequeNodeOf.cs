using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class DequeNodeOf<T>
    {
        private Node _left;
        private Node _right;

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public T PopLeft()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _left.Value;
            Count--;
            if (IsEmpty)
            {
                _left = null;
                _right = null;
            }
            else
            {
                _left = _left.Next;
            }
            return result;
        }

        public T PopRight()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _right.Value;
            Count--;
            if (IsEmpty)
            {
                _left = null;
                _right = null;
            }
            else
            {
                _right = _right.Previous;
            }
            return result;
        }

        public DequeNodeOf<T> PushLeft(T value)
        {
            Node oldLeft = _left;
            _left = new Node { Value = value, Next = oldLeft };
            if (IsEmpty)
            {
                _right = _left;
            }
            else
            {
                oldLeft.Previous = _left;
            }
            Count++;
            return this;
        }

        public DequeNodeOf<T> PushRight(T value)
        {
            Node oldRight = _right;
            _right = new Node { Value = value, Previous = oldRight };
            if (IsEmpty)
            {
                _left = _right;
            }
            else
            {
                oldRight.Next = _right;
            }
            Count++;
            return this;
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }
        }
    }
}
