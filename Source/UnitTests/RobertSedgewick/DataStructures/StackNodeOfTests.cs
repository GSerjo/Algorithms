using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class StackNodeOfTests
    {
        [Fact]
        public void Pop()
        {
            var stack = new StackNodeOf<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.False(stack.IsEmpty);
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());

            Assert.True(stack.IsEmpty);
        }
    }
}