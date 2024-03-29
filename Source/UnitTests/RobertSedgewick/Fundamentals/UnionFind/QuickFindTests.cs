﻿using System;
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
    }
}
