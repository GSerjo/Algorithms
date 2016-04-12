using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class SymbolTable<TKey, TValue>
        where TKey : IComparable
    {
        private Node _first;

        public TValue Get(TKey key)
        {
            Node node = Find(key);
            return node == null ? default(TValue) : node.Value;
        }

        public void Put(TKey key, TValue value)
        {
            Node node = Find(key);
            if (node == null)
            {
                _first = new Node { Key = key, Value = value, Next = _first };
            }
            else
            {
                node.Value = value;
            }
        }

        private Node Find(TKey key)
        {
            Node node = _first;
            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }


        private sealed class Node
        {
            public TKey Key { get; set; }
            public Node Next { get; set; }
            public TValue Value { get; set; }
        }
    }
}
