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
            var array = new int[] { 2, 0, 3, 4, 6, 5 };
            int[] result = InsertionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void MergeSorter_Sort()
        {
            var array = new int[] { 2, 0, 3, 4, 6, 5 };
            int[] result = MergeSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void QuickSorter_Sort()
        {
            var array = new int[] { 2, 0, 3, 4, 6, 5 };
            int[] result = QuickSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void SelectionSorter_Sort()
        {
            var array = new int[] { 2, 0, 3, 4, 6, 5 };
            int[] result = SelectionSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }

        [Fact]
        public void ShellSorter_Sort()
        {
            var array = new int[] { 2, 0, 3, 4, 6, 5 };
            int[] result = ShellSorter.Sort(array);
            Assert.True(Sorter.IsSorted(result));
        }
    }
}
