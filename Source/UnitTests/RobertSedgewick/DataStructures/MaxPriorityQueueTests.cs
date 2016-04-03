using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class MaxPriorityQueueTests
    {
        [Fact]
        public void Dequeue()
        {
            var queue = new MaxPriorityQueue<int>(5);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(0);
            queue.Enqueue(6);

            Assert.Equal(6, queue.Dequeue());
            Assert.Equal(3, queue.Count);

            Assert.Equal(5, queue.Dequeue());
            Assert.Equal(2, queue.Count);
        }
    }
}