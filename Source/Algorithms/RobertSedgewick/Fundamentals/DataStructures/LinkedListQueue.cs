using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    /// <summary>
    ///     FIFO
    /// </summary>
    public sealed class LinkedListQueue<TItem>
    {
        private int _capacity;
        private Node _head;
        private Node _tail;

        public int Count
        {
            get { return _capacity; }
        }

        public bool IsEmpty
        {
            get { return _head == null; }
        }

        public TItem Dequeue()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }
            TItem item = _head.Item;
            _head = _head.Next;
            if (IsEmpty)
            {
                _tail = null;
            }
            _capacity--;
            return item;
        }

        public void Enqueue(TItem item)
        {
            Node previouseTail = _tail;
            _tail = new Node
                {
                    Item = item,
                };
            if (IsEmpty)
            {
                _head = _tail;
            }
            else
            {
                previouseTail.Next = _tail;
            }
            _capacity++;
        }

        private sealed class Node
        {
            public TItem Item { get; set; }
            public Node Next { get; set; }
        }
    }
}
