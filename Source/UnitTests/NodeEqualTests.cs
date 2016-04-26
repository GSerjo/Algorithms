using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public sealed class NodeEqualTests
    {
        [Fact]
        public void Test()
        {
            var tree1 = new Node();
            tree1.Put(5);
            tree1.Put(2);
            tree1.Put(3);
            tree1.Put(4);
            tree1 = tree1.Put(7);

            var tree2 = new Node();
            tree2.Put(5);
            tree2.Put(2);
            tree2.Put(3);
            tree2.Put(4);
            tree2 = tree2.Put(7);

            bool result = tree1.SequenceEqual(tree2);

            bool result2 = NodeEqual(tree1, tree2);

            Assert.True(result);
            Assert.True(result2);
        }

        private static bool NodeEqual(Node tree1, Node tree2)
        {
            if (tree1 == null && tree2 == null)
            {
                return true;
            }
            else if (tree1 != null && tree2 == null)
            {
                return false;
            }
            else if (tree1 == null)
            {
                return false;
            }

            if (!(tree1.Value == tree2.Value && NodeEqual(tree1.Left, tree2.Left)))
            {
                return false;
            }
            if (!(tree1.Value == tree2.Value && NodeEqual(tree1.Right, tree2.Right)))
            {
                return false;
            }
            return true;
        }

        public sealed class Node : IEnumerable<int>
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }

            public IEnumerator<int> GetEnumerator()
            {
                yield return Value;

                if (Left != null)
                {
                    foreach (int item in Left)
                    {
                        yield return item;
                    }
                }
                if (Right != null)
                {
                    foreach (int item in Right)
                    {
                        yield return item;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public Node Put(int value)
            {
                return Put(this, value);
            }

            private static Node Put(Node root, int value)
            {
                if (root == null)
                {
                    return new Node { Value = value };
                }
                if (value < root.Value)
                {
                    root.Left = Put(root.Left, value);
                }
                else if (value > root.Value)
                {
                    root.Right = Put(root.Right, value);
                }
                else
                {
                    root.Value = value;
                }
                return root;
            }
        }
    }
}