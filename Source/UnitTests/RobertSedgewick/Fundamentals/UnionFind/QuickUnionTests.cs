using System;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickUnionTests
    {
        [Fact]
        public void QuickFind_TinyFile_True()
        {
            var dots = new Dots(@"DataStore\tinyUF.txt");
            var quickUnion = new QuickUnion(dots.Count);

            foreach (Tuple<int, int> item in dots.Items)
            {
                if (quickUnion.Connected(item.Item1, item.Item2))
                {
                    continue;
                }
                quickUnion.Union(item.Item1, item.Item2);
            }
            Assert.Equal(2, quickUnion.Count);
        }
    }
}