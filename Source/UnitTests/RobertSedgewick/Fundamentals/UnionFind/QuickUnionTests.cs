using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickUnionTests
    {
        private const string TinyFile = @"DataStore\tinyUF.txt";

        [Fact]
        public void QuickFind_TinyData_True()
        {
            string[] dataFile = File.ReadAllLines(TinyFile);
            int count = int.Parse(dataFile.First());

            var quickFind = new QuickUnion(count);

            for (int i = 1; i < dataFile.Length; i++)
            {
                List<int> data = dataFile[i].Split(null).Select(x => int.Parse(x)).ToList();
                int p = data[0];
                int q = data[1];

                if (quickFind.Connected(p, q))
                {
                    continue;
                }
                quickFind.Union(p, q);
                Console.WriteLine("P: {0}, Q: {1}", p, q);
            }

            Assert.Equal(2, quickFind.Count);
        }
    }
}
