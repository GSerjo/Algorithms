using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class LinkedListNodeTests
    {
        [Fact]
        public void AddFirst()
        {
            var linkedList = new LinkedListNodeOf<int>();

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
            var linkedList = new LinkedListNodeOf<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);

            Assert.Equal(2, linkedList.Tail.Value);
            Assert.Equal(1, linkedList.Head.Value);

            Assert.False(linkedList.IsEmpty);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void GetEnumerator()
        {
            var linkedList = new LinkedListNodeOf<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddLast(3);

            Assert.Equal(new[] { 2, 1, 3 }, linkedList.ToEnumerable());
        }

        [Fact]
        public void GetFirst()
        {
            var linkedList = new LinkedListNodeOf<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);

            int actual = linkedList.GetFirst();

            Assert.Equal(2, actual);
            Assert.Equal(1, linkedList.Count);
            Assert.False(linkedList.IsEmpty);
        }

        [Fact]
        public void Initial()
        {
            var linkedList = new LinkedListNodeOf<int>();

            Assert.Equal(0, linkedList.Count);
            Assert.True(linkedList.IsEmpty);
        }

        [Fact]
        public void RemoveLast()
        {
            var linkedList = new LinkedListNodeOf<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            linkedList.RemoveLast();

            Assert.Equal(2, linkedList.Tail.Value);
            Assert.Equal(2, linkedList.Count);
            Assert.False(linkedList.IsEmpty);

            linkedList.RemoveLast();
            linkedList.RemoveLast();
            Assert.True(linkedList.IsEmpty);
        }
    }
}
