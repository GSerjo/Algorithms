using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class TreeOf<T>
        where T : IComparable
    {
        private Node _root;

        public void PrintInOrder(Action<T> action)
        {
            PrintInOrder(_root, action);
        }

        public void Put(T value)
        {
            _root = Put(_root, value);
        }

        private static void PrintInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            PrintInOrder(node.Left, action);
            action(node.Value);
            PrintInOrder(node.Right, action);
        }

        private static Node Put(Node node, T value)
        {
            if (node == null)
            {
                return new Node { Value = value };
            }
            int compare = value.CompareTo(node.Value);
            if (compare > 0)
            {
                node.Right = Put(node.Right, value);
            }
            else if (compare < 0)
            {
                node.Left = Put(node.Left, value);
            }
            else
            {
                node.Value = value;
            }
            return node;
        }


        private sealed class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
        }
    }
}
