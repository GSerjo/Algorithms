using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class StackArrayOfTests
    {
        [Fact]
        public void Empty_NewStack_True()
        {
            var stack = new StackArrayOf<int>();
            Assert.True(stack.IsEmpty);
        }

        [Fact]
        public void Pop_EmptyStack_Exception()
        {
            var stack = new StackArrayOf<int>();
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_NewStack_Ok()
        {
            var stack = new StackArrayOf<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);

            Assert.Equal(8, stack.Count);
            Assert.Equal(8, stack.Pop());
            Assert.Equal(7, stack.Pop());
            Assert.Equal(6, stack.Pop());
            Assert.Equal(5, stack.Pop());
            Assert.Equal(4, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_NewStack_Ok()
        {
            var stack = new StackArrayOf<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty);
            Assert.Equal(1, stack.Count);
        }
    }
}
