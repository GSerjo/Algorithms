namespace Algorithms.DataStructures
{
    public class StackStructure<T>
    {
        private readonly Node<T> _head = new Node<T>();

        public T Pop()
        {
            Node<T> node = _head.Next;
            if (node == null)
            {
                return default(T);
            }
            _head.Next = node.Next;
            return node.Data;
        }

        public void Push(T data)
        {
            var node = new Node<T> { Data = data, Next = _head.Next };
            _head.Next = node;
        }

        private sealed class Node<TData>
        {
            public TData Data { get; set; }
            public Node<TData> Next { get; set; }
        }
    }
}
