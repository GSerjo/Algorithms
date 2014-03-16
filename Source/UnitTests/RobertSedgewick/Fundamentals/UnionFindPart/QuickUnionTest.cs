using System;
using System.Collections.Generic;
using Algorithms.RobertSedgewick.Fundamentals.UnionFindPart;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class QuickUnionTest : UnionFindTest
    {
        [Fact]
        public void Union_TinyFile()
        {
            int capacity = FileCapacity(TinyFile);
            var unionFind = new QuickUnion(capacity);
            IEnumerable<int[]> data = FileData(TinyFile);
            foreach (var item in data)
            {
                unionFind.Union(item[0], item[1]);
                Console.WriteLine(ArrayToString(unionFind.Indexes));
            }
            Assert.Equal(new[] { 1, 1, 1, 8, 3, 0, 5, 1, 8, 8 }, unionFind.Indexes);
        }
    }
}
