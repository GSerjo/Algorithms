using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class StackOfTests
    {
        [Fact]
        public void Empty_NewStack_True()
        {
            var stack = new StackOf<int>();
            Assert.True(stack.IsEmpty);
        }

        [Fact]
        public void Pop_EmptyStack_Exception()
        {
            var stack = new StackOf<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_NewStack_Ok()
        {
            var stack = new StackOf<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty);
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_NewStack_Ok()
        {
            var stack = new StackOf<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty);
            Assert.Equal(1, stack.Count);
        }
    }
}
