using Algorithms.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public sealed class CoinChangerTests
    {
        [Fact]
        public void Change()
        {
            int result = CoinChanger.Change(10);
            Assert.Equal(3, result);
        }
    }
}
