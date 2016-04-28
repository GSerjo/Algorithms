using System.Collections.Generic;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class TreeOfTests
    {
        [Fact]
        public void PrintInOrder()
        {
            var tree = new TreeOf<int>();
            tree.Put(5);
            tree.Put(7);
            tree.Put(4);

            var result = new List<int>();
            tree.PrintInOrder(result.Add);

            Assert.Equal(new[] { 4, 5, 7 }, result);
        }
    }
}
