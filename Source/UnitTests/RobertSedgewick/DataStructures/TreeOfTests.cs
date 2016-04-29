using System.Collections.Generic;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class TreeOfTests
    {
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
        public void Sum()
        {
            var tree = new TreeOf();
            tree.Put(5)
                .Put(3)
                .Put(2)
                .Put(1);

            int result =  tree.Sum();

            Assert.Equal(11, result);
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
    }
}
