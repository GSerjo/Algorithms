using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class TreeOf : IEnumerable<int>
    {
        private int _deeppestLevel;
        private Node _root;

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int value in _root)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddAllGreaterValuesToEveryNode()
        {
            var sum = 0;
            AddAllGreaterValuesToEveryNode(_root, ref sum);
        }

        public int FindDeeppest()
        {
            FindDeepest(_root, 0);
            return _deeppestLevel;
        }

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

        public void Inorder(Action<int> action)
        {
            Inorder(_root, action);
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
        }

        public void Postorder(Action<int> action)
        {
            Postorder(_root, action);
        }

        public void Preoder(Action<int> action)
        {
            Preoder(_root, action);
        }

        public TreeOf Put(int value)
        {
            _root = Put(_root, value);
            return this;
        }

        public int Sum()
        {
            return Sum(_root);
        }

        public Dictionary<int, int> VerticalSum()
        {
            var result = new Dictionary<int, int>();
            VerticalSum(_root, 0, result);
            return result;
        }

        private static void AddAllGreaterValuesToEveryNode(Node node, ref int sum)
        {
            if (node == null)
            {
                return;
            }
            AddAllGreaterValuesToEveryNode(node.Right, ref sum);
            sum = sum + node.Value;
            node.Value = sum;
            AddAllGreaterValuesToEveryNode(node.Left, ref sum);
        }

        private void FindDeepest(Node node, int level)
        {
            if (node == null)
            {
                return;
            }
            if (level > _deeppestLevel)
            {
                _deeppestLevel = level;
            }
            FindDeepest(node.Left, level + 1);
            FindDeepest(node.Right, level + 1);
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

        private static void Inorder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }
            Inorder(node.Left, action);
            action(node.Value);
            Inorder(node.Right, action);
        }

        private static bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }
            if (node.Value < min || node.Value > max)
            {
                return false;
            }
            return IsBinarySearchTree(node.Left, min, node.Value) && IsBinarySearchTree(node.Right, node.Value, max);
        }

        private static void Postorder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }
            Postorder(node.Left, action);
            Postorder(node.Right, action);
            action(node.Value);
        }

        private static void Preoder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }
            action(node.Value);
            Preoder(node.Left, action);
            Preoder(node.Right, action);
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

        private static int Sum(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return Sum(node.Left) + Sum(node.Right) + node.Value;
        }

        private static void VerticalSum(Node node, int distance, Dictionary<int, int> map)
        {
            if (node == null)
            {
                return;
            }
            if (map.ContainsKey(distance))
            {
                map[distance] += node.Value;
            }
            else
            {
                map[distance] = node.Value;
            }
            VerticalSum(node.Left, distance - 1, map);
            VerticalSum(node.Right, distance + 1, map);
        }


        private sealed class Node : IEnumerable<int>
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }

            public IEnumerator<int> GetEnumerator()
            {
                yield return Value;

                if (Left != null)
                {
                    foreach (int value in Left)
                    {
                        yield return value;
                    }
                }

                if (Right != null)
                {
                    foreach (int value in Right)
                    {
                        yield return value;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
