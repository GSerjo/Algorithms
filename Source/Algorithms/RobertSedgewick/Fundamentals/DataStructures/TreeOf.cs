using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class TreeOf
    {
        private Node _root;

        public int GetMin()
        {
            if (_root == null)
            {
                return 0;
            }
            Node curent = _root;

            while (curent.Left != null)
            {
                curent = curent.Left;
            }
            return curent.Value;
        }

        public int GetMinRecursive()
        {
            return GetMinRecursive(_root);
        }

        public bool HasPathSumBySubtract(int sum)
        {
            return HasPathSumBySubtract(_root, sum);
        }

        public bool HasPathSumBySum(int sum)
        {
            return HasPathSumBySum(_root, sum, 0);
        }

        public void PrintInorder(Action<int> action)
        {
            PrintInorder(_root, action);
        }

        public void PrintPostorder(Action<int> action)
        {
            PrintPostorder(_root, action);
        }

        public TreeOf Put(int value)
        {
            _root = Put(_root, value);
            return this;
        }

        private static int GetMinRecursive(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else if (node.Left == null)
            {
                return node.Value;
            }
            return GetMinRecursive(node.Left);
        }

        private static bool HasPathSumBySum(Node node, int sum, int current)
        {
            if (node == null)
            {
                return sum == current;
            }
            int subSum = current + node.Value;
            if (HasPathSumBySum(node.Left, sum, subSum) || HasPathSumBySum(node.Right, sum, subSum))
            {
                return true;
            }
            return false;
        }

        private static bool HasPathSumBySubtract(Node node, int sum)
        {
            if (node == null)
            {
                return sum == 0;
            }
            int subSum = sum - node.Value;
            if (HasPathSumBySubtract(node.Left, subSum) || HasPathSumBySubtract(node.Right, subSum))
            {
                return true;
            }
            return false;
        }

        private static void PrintInorder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }
            PrintInorder(node.Left, action);
            action(node.Value);
            PrintInorder(node.Right, action);
        }

        private static void PrintPostorder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }
            PrintPostorder(node.Left, action);
            PrintPostorder(node.Right, action);
            action(node.Value);
        }

        private static Node Put(Node node, int value)
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
            public int Value { get; set; }
        }
    }
}
