﻿using System;
using System.Collections.Generic;
using Algorithms.RobertSedgewick.UnionFindPart;
using Xunit;

namespace UnitTests.RobertSedgewick.UnionFindPart
{
    public sealed class QuickFindTest : UnionFindTest
    {
        [Fact]
        public void Union_TinyFile()
        {
            int capacity = FileCapacity(TinyFile);
            var unionFind = new QuickFind(capacity);
            IEnumerable<int[]> data = FileData(TinyFile);
            foreach (var item in data)
            {
                unionFind.Union(item[0], item[1]);
                Console.WriteLine(ArrayToString(unionFind.Indexes));
            }
            Assert.Equal(new[] { 1, 1, 1, 8, 8, 1, 1, 1, 8, 8 }, unionFind.Indexes);
        }
    }
}
