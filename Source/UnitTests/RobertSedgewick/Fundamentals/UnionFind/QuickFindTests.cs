using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.UnionFind;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickFindTests
    {
        [Fact]
        public void QuickFind_TinyFile_True()
        {
            var dots = new Dots(@"DataStore\tinyUF.txt");
            var quickFind = new QuickFind(dots.Count);

            foreach (Tuple<int, int> item in dots.Items)
            {
                if (quickFind.Connected(item.Item1, item.Item2))
                {
                    continue;
                }
                quickFind.Union(item.Item1, item.Item2);
            }
            Assert.Equal(2, quickFind.Count);
        }


        private sealed class Dots
        {
            public Dots(string filePath)
            {
                string[] content = File.ReadAllLines(filePath);
                Count = int.Parse(content[0]);
                Items = content.Skip(1)
                              .Select(x => x.Split(null))
                              .Select(x => Tuple.Create(int.Parse(x[0]), int.Parse(x[1])))
                              .ToList();
            }

            public int Count { get; }
            public List<Tuple<int, int>> Items { get; }
        }
    }
}
