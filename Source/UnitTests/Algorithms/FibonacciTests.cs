using Algorithms;
using Xunit;

namespace UnitTests.Algorithms
{
    public sealed class FibonacciTests
    {
        [Fact]
        public void For()
        {
            int result = Fibonacci.For(4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void For1()
        {
            int result = Fibonacci.For1(4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void For2()
        {
            int result = Fibonacci.For2(4);
            Assert.Equal(3, result);
        }
    }
}
