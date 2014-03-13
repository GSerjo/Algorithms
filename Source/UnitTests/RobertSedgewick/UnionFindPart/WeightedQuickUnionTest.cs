﻿using System;
using System.Collections.Generic;
using Algorithms.RobertSedgewick.UnionFindPart;
using Xunit;

namespace UnitTests.RobertSedgewick.UnionFindPart
{
    public sealed class WeightedQuickUnionTest : UnionFindTest
    {
        [Fact]
        public void Union_TinyFile()
        {
            int capacity = FileCapacity(TinyFile);
            var unionFind = new WeightedQuickUnion(capacity);
            IEnumerable<int[]> data = FileData(TinyFile);
            foreach (var item in data)
            {
                unionFind.Union(item[0], item[1]);
                Console.WriteLine(ArrayToString(unionFind.Indexes));
            }
            Assert.Equal(new[] { 6, 2, 6, 4, 4, 6, 6, 2, 4, 4 }, unionFind.Indexes);
        }
    }
}