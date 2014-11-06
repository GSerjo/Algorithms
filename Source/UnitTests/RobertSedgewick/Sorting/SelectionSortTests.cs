using System;
using Algorithms.RobertSedgewick.Fundamentals.Sorting;
using Xunit;

namespace UnitTests.RobertSedgewick.Sorting
{
    public sealed class SelectionSortTests : SortTest
    {
        [Fact]
        public void Sort()
        {
            var array = new int[] { 1, 0, 3, 2, 5, 2 };
            SelectionSort.Sort(array);
            Assert.True(IsSorted(array));
        }
    }
}
