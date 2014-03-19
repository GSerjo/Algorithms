using System;
using Algorithms.RobertSedgewick.Sorting;
using Xunit;

namespace UnitTests.RobertSedgewick.Sorting
{
    public sealed class SelectionSorterTest
    {
        [Fact]
        public void Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            SelectionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(array));
        }
    }
}
