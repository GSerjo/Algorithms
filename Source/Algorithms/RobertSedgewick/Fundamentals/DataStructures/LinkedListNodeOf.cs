using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class LinkedListNodeOf<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public Node Head { get; private set; }
        public bool IsEmpty => Count == 0;
        public Node Tail { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddFirst(T value)
        {
            Node old = Head;
            Head = new Node { Value = value };

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                Head.Next = old;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            Node old = Tail;
            Tail = new Node { Value = value };

            if (IsEmpty)
            {
                Head = Tail;
            }
            else
            {
                old.Next = Tail;
            }
            Count++;
        }

        public void Reverse()
        {
            Node result = null;
            Node current = Head;
            while (current != null)
            {
                Node temp = current.Next;
                current.Next = result;
                result = current;
                current = temp;
            }
            Head = result;
        }

        public T GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = Head.Value;
            RemoveFirst();
            return result;
        }

        public IEnumerable<T> ToEnumerable()
        {
            IEnumerator<T> enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        private void RemoveFirst()
        {
            Head = Head.Next;
            Count--;
            if (IsEmpty)
            {
                Head = null;
                Tail = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            if (Count == 1)
            {
                RemoveFirst();
                return;
            }
            Node current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }
            Tail = current;
            Tail.Next = null;
            Count--;
            if (IsEmpty)
            {
                Head = null;
                Tail = null;
            }
        }


        public sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
