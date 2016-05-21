using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class TreeOfTests
    {
        [Fact]
        public void AddAllGreaterValuesToEveryNode()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(3)
                .Put(6)
                .Put(8)
                .Put(2)
                .Put(4);

            tree.AddAllGreaterValuesToEveryNode();

            List<int> result = tree.Select(x => x).ToList();
            Assert.Equal(new[] { 26, 33, 35, 30, 15, 21, 8 }, result);
        }

        [Fact]
        public void GetMin()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4)
                .Put(3)
                .Put(2)
                .Put(8)
                .Put(1);

            Assert.Equal(1, tree.GetMin());
        }

        [Fact]
        public void GetMinRecursive()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4)
                .Put(3)
                .Put(2)
                .Put(8)
                .Put(1);

            Assert.Equal(1, tree.GetMinRecursive());
        }

        [Fact]
        public void HasPathSumBySubtract()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4)
                .Put(3)
                .Put(2)
                .Put(8)
                .Put(1);

            bool result = tree.HasPathSumBySubtract(20);
            Assert.True(result);

            result = tree.HasPathSumBySubtract(21);
            Assert.False(result);
        }

        [Fact]
        public void HasPathSumBySum()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4)
                .Put(3)
                .Put(2)
                .Put(8)
                .Put(1);

            bool result = tree.HasPathSumBySum(20);
            Assert.True(result);

            result = tree.HasPathSumBySum(21);
            Assert.False(result);
        }

        [Fact]
        public void Inorder()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4);

            var result = new List<int>();
            tree.Inorder(result.Add);

            Assert.Equal(new[] { 4, 5, 7 }, result);
        }

        [Fact]
        public void Postorder()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4);

            var result = new List<int>();
            tree.Postorder(result.Add);

            Assert.Equal(new[] { 4, 7, 5 }, result);
        }

        [Fact]
        public void IsBinarySearchTree()
        {
            var tree = new TreeOf();
            tree.Put(20)
                .Put(30)
                .Put(25)
                .Put(40)
                .Put(10)
                .Put(8)
                .Put(15);

            bool result = tree.IsBinarySearchTree();
            Assert.True(result);
        }

        [Fact]
        public void BottomView()
        {
            var tree = new TreeOf();
            tree.Put(20)
                .Put(30)
                .Put(25)
                .Put(40)
                .Put(10)
                .Put(8)
                .Put(15);

            List<int> result = tree.BottomView();
            Assert.Equal(new[] { 25, 10, 8, 30, 40 }, result);
        }

        [Fact]
        public void FindDeeppest()
        {
            var tree = new TreeOf();
            tree.Put(20)
                .Put(30)
                .Put(25)
                .Put(40)
                .Put(10)
                .Put(8)
                .Put(15)
                .Put(50);

            int result = tree.FindDeeppest();
            Assert.Equal(3, result);
        }

        [Fact]
        public void Preoder()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(7)
                .Put(4);

            var result = new List<int>();
            tree.Preoder(result.Add);

            Assert.Equal(new[] { 5, 4, 7 }, result);
        }

        [Fact]
        public void Sum()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(3)
                .Put(2)
                .Put(1);

            int result = tree.Sum();

            Assert.Equal(11, result);
        }

        [Fact]
        public void TrappingRainWater()
        {
            int result = TrappingRainWater(new[] { 3, 0, 0, 2, 0, 4 });
            Assert.Equal(10, result);
        }

        [Fact]
        public void VerticalSum()
        {
            var tree = new TreeOf();
            tree.Put(6)
                .Put(8)
                .Put(4)
                .Put(3)
                .Put(5)
                .Put(7)
                .Put(9);

            Dictionary<int, int> result = tree.VerticalSum();

            var expected = new Dictionary<int, int>
            {
                { 0, 18 }, { -1, 4 }, { -2, 3 }, { 1, 8 }, { 2, 9 }
            };
            Assert.Equal(expected, result);
        }

        private static int TrappingRainWater(int[] array)
        {
            if (array == null || array.Length <= 2)
            {
                return 0;
            }
            var left = new int[array.Length];
            var right = new int[array.Length];
            left[0] = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                left[i] = Math.Max(left[i - 1], array[i]);
            }
            right[array.Length - 1] = array[array.Length - 1];
            for (int i = array.Length - 2; i >= 0; i--)
            {
                right[i] = Math.Max(array[i], right[i + 1]);
            }
            var result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                result += Math.Min(left[i], right[i]) - array[i];
            }
            return result;
        }
    }
}
