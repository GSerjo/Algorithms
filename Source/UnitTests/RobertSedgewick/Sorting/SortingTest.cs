using System;
using Algorithms.RobertSedgewick.Sorting;
using Xunit;

namespace UnitTests.RobertSedgewick.Sorting
{
    public sealed class SortingTest
    {
        [Fact]
        public void InsertionSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            InsertionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(array));
        }

        [Fact]
        public void SelectionSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            SelectionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(array));
        }

        [Fact]
        public void ShellSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            ShellSorter.Sort(array);
            Assert.True(Sorter.IsSorted(array));
        }
    }
}
