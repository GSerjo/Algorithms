using System;
using Algorithms.DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public sealed class StackStructureArrayTest
    {
        [Fact]
        public void Pop_MoreThenExist_ThrowException()
        {
            var stack = new StackStructureArray<int>();
            stack.Push(1)
                 .Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Throws(typeof(IndexOutOfRangeException), () => stack.Pop());
        }

        [Fact]
        public void Push()
        {
            var stack = new StackStructureArray<int>();
            stack.Push(1)
                 .Push(2);
            string result = stack.ToString();
            Assert.Equal("{2;1;}", result);
        }
    }
}
