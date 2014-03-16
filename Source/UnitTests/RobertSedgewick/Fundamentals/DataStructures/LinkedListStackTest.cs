using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class LinkedListStackTest
    {
        [Fact]
        public void Count_PopFromStack_CountDecreased()
        {
            var stack = new LinkedListStack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(3, stack.Count);

            stack.Pop();
            Assert.Equal(2, stack.Count);

            stack.Pop();
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Count_PushIntoStack_CountIncreased()
        {
            var stack = new LinkedListStack<int>();

            stack.Push(0);
            Assert.Equal(1, stack.Count);

            stack.Push(1);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void IsEmpty_NewStack_True()
        {
            var stack = new LinkedListStack<int>();
            Assert.True(stack.IsEmpty);
        }

        [Fact]
        public void Pop_IntoStack_CorrectOrder()
        {
            var stack = new LinkedListStack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Pop());
        }
    }
}
