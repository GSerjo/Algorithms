using Algorithms.RobertSedgewick.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class LinkedListQueueTest
    {
        [Fact]
        public void Count_DequeueFromQueue_CountDecreased()
        {
            var queue = new LinkedListQueue<int>();
            queue.Enqueue(0);
            queue.Enqueue(0);

            Assert.Equal(2, queue.Count);

            queue.Dequeue();
            Assert.Equal(1, queue.Count);

            queue.Dequeue();
            Assert.Equal(0, queue.Count);

            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Count_EnqueueIntoQueue_CountIncreased()
        {
            var queue = new LinkedListQueue<int>();

            Assert.Equal(0, queue.Count);

            queue.Enqueue(0);

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Dequeue_NewQueue_CorrectOrder()
        {
            var stack = new LinkedListQueue<int>();
            stack.Enqueue(0);
            stack.Enqueue(1);
            stack.Enqueue(2);

            Assert.Equal(0, stack.Dequeue());
            Assert.Equal(1, stack.Dequeue());
            Assert.Equal(2, stack.Dequeue());
        }

        [Fact]
        public void IsEmpty_NewQueue_True()
        {
            var queue = new LinkedListQueue<int>();
            Assert.True(queue.IsEmpty);
        }
    }
}
