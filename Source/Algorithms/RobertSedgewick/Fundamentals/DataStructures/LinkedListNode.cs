namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class LinkedListNode<T>
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

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


        public sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
