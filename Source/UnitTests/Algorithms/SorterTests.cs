using System;
using System.Collections.Generic;
using Algorithms;
using Xunit;

namespace UnitTests.Algorithms
{
    public sealed class SorterTests
    {
        [Fact]
        public void Insert()
        {
            var source = new List<int> { 3, 5, 1, 0, 7 };
            var expected = new List<int> { 0, 1, 3, 5, 7 };
            List<int> actual = Sorter.Insert(source);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Merge()
        {
            var source = new List<int> { 3, 5, 1, 0, 7 };
            var expected = new List<int> { 0, 1, 3, 5, 7 };
            List<int> actual = Sorter.Merge(source);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Quick()
        {
            var source = new List<int> { 3, 5, 1, 0, 7 };
            var expected = new List<int> { 0, 1, 3, 5, 7 };
            Sorter.Quick(source, 0, source.Count);
            Assert.Equal(expected, source);
        }

        [Fact]
        public void Selection()
        {
            var source = new List<int> { 3, 5, 1, 0, 7 };
            var expected = new List<int> { 0, 1, 3, 5, 7 };
            List<int> actual = Sorter.Selection(source);
            Assert.Equal(expected, actual);
        }
    }
}
