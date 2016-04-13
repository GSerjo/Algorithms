using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class LinkedListNodeTests
    {
        [Fact]
        public void Initial()
        {
            var linkedList = new LinkedListNode<int>();

            Assert.Equal(0, linkedList.Count);
            Assert.True(linkedList.IsEmpty);
        }

        [Fact]
        public void AddFirst()
        {
            var linkedList = new LinkedListNode<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);

            Assert.Equal(1, linkedList.Tail.Value);
            Assert.Equal(2, linkedList.Head.Value);

            Assert.False(linkedList.IsEmpty);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void AddLast()
        {
            var linkedList = new LinkedListNode<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);

            Assert.Equal(2, linkedList.Tail.Value);
            Assert.Equal(1, linkedList.Head.Value);

            Assert.False(linkedList.IsEmpty);
            Assert.Equal(2, linkedList.Count);
        }
    }
}
