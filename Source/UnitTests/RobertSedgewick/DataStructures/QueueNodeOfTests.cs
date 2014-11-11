using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class QueueNodeOfTests
    {
        [Fact]
        public void Dequeue_EmptyQueue_ThrowException()
        {
            var queue = new QueueNodeOf<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Dequeue_NewQueue_Ok()
        {
            var queue = new QueueNodeOf<int>();
            queue.Enqueue(0)
                 .Enqueue(1)
                 .Enqueue(2);

            Assert.Equal(0, queue.Dequeue());
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());

            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Enqueue_NewQueue_Ok()
        {
            var queue = new QueueNodeOf<int>();
            queue.Enqueue(0)
                 .Enqueue(1);
            Assert.Equal(2, queue.Count);
            Assert.False(queue.IsEmpty);
        }

        [Fact]
        public void IsEmpty_NewQueue_True()
        {
            var queue = new QueueNodeOf<int>();
            Assert.True(queue.IsEmpty);
            Assert.Equal(0, queue.Count);
        }
    }
}
