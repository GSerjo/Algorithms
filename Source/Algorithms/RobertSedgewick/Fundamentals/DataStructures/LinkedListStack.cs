using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class LinkedListStack<TItem>
    {
        private int _capacity;
        private Node _root;

        public int Count
        {
            get { return _capacity; }
        }

        public bool IsEmpty
        {
            get { return _root == null; }
        }

        public TItem Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            TItem result = _root.Item;
            _root = _root.Next;
            _capacity--;
            return result;
        }

        public void Push(TItem item)
        {
            var node = new Node
                {
                    Item = item,
                    Next = _root
                };
            _root = node;
            _capacity++;
        }

        private sealed class Node
        {
            public TItem Item { get; set; }
            public Node Next { get; set; }
        }
    }
}
