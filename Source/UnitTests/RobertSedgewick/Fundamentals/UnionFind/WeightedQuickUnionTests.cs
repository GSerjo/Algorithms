using System;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class WeightedQuickUnionTests
    {
        [Fact]
        public void QuickFind_TinyFile_True()
        {
            var dots = new Dots(@"DataStore\tinyUF.txt");
            var weightedQuickUnion = new WeightedQuickUnion(dots.Count);

            foreach (Tuple<int, int> item in dots.Items)
            {
                if (weightedQuickUnion.Connected(item.Item1, item.Item2))
                {
                    continue;
                }
                weightedQuickUnion.Union(item.Item1, item.Item2);
            }
            Assert.Equal(2, weightedQuickUnion.Count);
        }
    }
}
