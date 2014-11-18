using Algorithms.RobertSedgewick.Fundamentals.Sorting;
using Xunit;

namespace UnitTests.RobertSedgewick.Sorting
{
    public sealed class MergeSortTests : SortTest
    {
        [Fact]
        public void Sort()
        {
            var array = new int[] { 1, 0, 3, 2, 5 };
            MergeSort.Sort(array);
            Assert.True(IsSorted(array));
        }
    }
}