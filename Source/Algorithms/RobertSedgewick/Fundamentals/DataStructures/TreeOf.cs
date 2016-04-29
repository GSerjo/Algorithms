using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class TreeOf<T>
        where T : IComparable
    {
        private Node _root;

        public T GetMin()
        {
            if (_root == null)
            {
                return default(T);
            }
            Node curent = _root;

            while (curent.Left != null)
            {
                curent = curent.Left;
            }
            return curent.Value;
        }

        public T GetMinRecursive()
        {
            return GetMinRecursive(_root);
        }

        public void PrintInorder(Action<T> action)
        {
            PrintInorder(_root, action);
        }

        public void PrintPostorder(Action<T> action)
        {
            PrintPostorder(_root, action);
        }

        public void Put(T value)
        {
            _root = Put(_root, value);
        }

        private static T GetMinRecursive(Node node)
        {
            if (node == null)
            {
                return default(T);
            }
            else if (node.Left == null)
            {
                return node.Value;
            }
            return GetMinRecursive(node.Left);
        }

        private static void PrintInorder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            PrintInorder(node.Left, action);
            action(node.Value);
            PrintInorder(node.Right, action);
        }

        private static void PrintPostorder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            PrintPostorder(node.Left, action);
            PrintPostorder(node.Right, action);
            action(node.Value);
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
