using System;
using Algorithms.DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public sealed class StackStructureTest
    {
        [Fact]
        public void StackStructure()
        {
            var stack = new StackStructure<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Throws(typeof(IndexOutOfRangeException), () => stack.Pop());
        }
    }
}
