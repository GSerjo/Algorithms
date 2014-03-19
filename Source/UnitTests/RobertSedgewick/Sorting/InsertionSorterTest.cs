using System;
using Algorithms.RobertSedgewick.Sorting;
using Xunit;

namespace UnitTests.RobertSedgewick.Sorting
{
    public sealed class InsertionSorterTest
    {
        [Fact]
        public void Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            InsertionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(array));
        }
    }
}
