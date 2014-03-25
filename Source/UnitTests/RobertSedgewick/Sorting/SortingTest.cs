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
            IComparable[] result = InsertionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void MergeSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            IComparable[] result = MergeSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void SelectionSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            IComparable[] result = SelectionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void ShellSorter_Sort()
        {
            var array = new IComparable[] { 2, 0, 3, 4, 6, 5 };
            IComparable[] result = ShellSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }
    }
}
