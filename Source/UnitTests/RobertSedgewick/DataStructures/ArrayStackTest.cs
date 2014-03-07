using Algorithms.RobertSedgewick.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class ArrayStackTest
    {
        [Fact]
        public void Count_PopFromStack_CountDecreased()
        {
            var stack = new ArrayStack<int>();
            stack.Push(0);
            stack.Push(0);

            Assert.Equal(2, stack.Count);

            stack.Pop();
            Assert.Equal(1, stack.Count);

            stack.Pop();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Count_PushIntoNewStack_CountIncreased()
        {
            var stack = new ArrayStack<int>();

            Assert.Equal(0, stack.Count);

            stack.Push(0);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void IsEmpty_NewStack_True()
        {
            var stack = new ArrayStack<int>();
            Assert.True(stack.IsEmpty);
        }

        [Fact]
        public void Pop_NewStack_CorrectOrder()
        {
            var stack = new ArrayStack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Pop());
        }
    }
}
