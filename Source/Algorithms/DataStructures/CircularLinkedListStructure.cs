namespace Algorithms.DataStructures
{
    public class CircularLinkedListStructure<T>
    {
        private Node _tail;

        public CircularLinkedListStructure<T> AddFirst(T value)
        {
            var node = new Node { Value = value };
            if (_tail == null)
            {
                _tail = node;
                _tail.Next = node;
            }
            else
            {
                node.Next = _tail.Next;
                _tail.Next = node;
            }
            return this;
        }

        private sealed class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
        }
    }
}
