using Algorithms.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public sealed class LongestIncreasingSubsequenceTests
    {
        [Fact]
        public void FindLength()
        {
            var array = new[] { 7, 2, 1, 3, 8, 4, 9, 1, 2, 6, 5, 9, 3, 8, 1 };
            int result = LongestIncreasingSubsequence.FindLength(array);

            Assert.Equal(5, result);
        }

        [Fact]
        public void FindMultipleLength()
        {
            var array = new[] { 3, 6, 7, 12 };
            int result = LongestIncreasingSubsequence.FindMultipleLength(array);

            Assert.Equal(3, result);
        }
    }
}
