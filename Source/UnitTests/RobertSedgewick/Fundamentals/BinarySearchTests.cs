using Algorithms.RobertSedgewick.Fundamentals;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals
{
    public sealed class BinarySearchTests
    {
        [Fact]
        public void BinarySearch_Null_MinusOne()
        {
            int result = BinarySearch.Search(1, null);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_KeyExists_Ok()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };

            int result = BinarySearch.Search(3, data);

            Assert.Equal(2, result);
        }

        [Fact]
        public void BinarySearch_KeyNotExists_Ok()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };

            int result = BinarySearch.Search(33, data);

            Assert.Equal(-1, result);
        }
    }
}
