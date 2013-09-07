using System.Collections.Generic;
using Algorithms;
using Xunit;

namespace UnitTests.Algorithms
{
    public sealed class SorterTests
    {
        [Fact]
        public void Selection()
        {
            var source = new List<int> { 3, 5, 1, 0, 7 };
            var expected = new List<int> { 0, 1, 3, 5, 7 };
            List<int> actual = Sorter.Selection(source);
            Assert.Equal(expected, actual);
        }
    }
}
