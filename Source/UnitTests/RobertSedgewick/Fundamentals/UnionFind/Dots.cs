using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFind
{
    internal sealed class Dots
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
