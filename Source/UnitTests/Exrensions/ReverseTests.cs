using Algorithms.Exrensions;
using Xunit;

namespace UnitTests.Exrensions
{
    public sealed class ReverseTests
    {
        [InlineData("abcd", "dcba")]
        [InlineData("abcde", "edcba")]
        [InlineData(null, "")]
        [Theory]
        public void Reverse_Value_Ok(string input, string expected)
        {
            Assert.Equal(expected, input.Reverse());
        }
    }
}
