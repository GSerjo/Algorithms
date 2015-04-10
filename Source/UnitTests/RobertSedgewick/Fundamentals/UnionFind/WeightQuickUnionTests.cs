using System;
using System.IO;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class WeightQuickUnionTests
    {
        [Fact]
        public void WeightQuickUnion_TinyData_Success()
        {
            string[] rawData = File.ReadAllLines(@"DataStore\tinyUF.txt");
            int count = int.Parse(rawData[0]);

            var quickUnion = new WeightQuickUnion(count);

            for (int i = 1; i < rawData.Length; i++)
            {
                string[] items = rawData[i].Split(null);
                int p = int.Parse(items[0]);
                int q = int.Parse(items[1]);

                if (quickUnion.Connected(p, q))
                {
                    continue;
                }

                quickUnion.Union(p, q);
            }

            Assert.Equal(2, quickUnion.Count);
        }
    }
}
