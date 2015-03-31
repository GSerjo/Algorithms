using System;
using System.IO;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickFindTests
    {
        [Fact]
        public void QuickFind_TinyData_Success()
        {
            string[] rawData = File.ReadAllLines(@"DataStore\tinyUF.txt");
            int count = int.Parse(rawData[0]);

            var quickFind = new QuickFind(count);

            for (int i = 1; i < rawData.Length; i++)
            {
                string[] items = rawData[i].Split(null);
                int p = int.Parse(items[0]);
                int q = int.Parse(items[1]);

                if (quickFind.Connected(p, q))
                {
                    continue;
                }

                quickFind.Union(p, q);
            }

            Assert.Equal(2, quickFind.Count);
        }
    }
}
