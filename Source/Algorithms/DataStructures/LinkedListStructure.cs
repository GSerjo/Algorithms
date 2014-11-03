using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures
{
    public sealed class LinkedListStructure<T> : ICollection<T>
    {
        private readonly Node _head = new Node();
        private readonly Node _tail = new Node();

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public LinkedListStructure<T> AddFirst(T value)
        {
            var node = new Node { Value = value, Next = _head.Next };
            Count++;
            if (Count == 1)
            {
                _tail.Next = node;
            }
            _head.Next = node;
            return this;
        }

        public LinkedListStructure<T> AddLast(T value)
        {
            var node = new Node { Value = value };
            Count++;
            if (Count == 1)
            {
                _head.Next = node;
                _tail.Next = node;
                return this;
            }
            _tail.Next.Next = node;
            _tail.Next = node;
            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("{");
            Node node = _head.Next;
            while (node != null)
            {
                builder.AppendFormat("{0};", node.Value);
                node = node.Next;
            }
            builder.Append("}");
            return builder.ToString();
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            _head.Next = null;
            _tail.Next = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node node = _head.Next;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = _head.Next;
            while (node.Next != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }


        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
