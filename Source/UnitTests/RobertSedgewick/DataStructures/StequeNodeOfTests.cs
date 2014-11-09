using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class StequeNodeOfTests
    {
        [Fact]
        public void Enqueue_NewSteque_Ok()
        {
            var steque = new StequeNodeOf<int>();
            steque.Enqueue(0)
                  .Enqueue(1);

            Assert.False(steque.IsEmpty);
            Assert.Equal(2, steque.Count);
        }

        [Fact]
        public void IsEmpty_NewSteque_True()
        {
            var steque = new StequeNodeOf<int>();
            Assert.Equal(0, steque.Count);
            Assert.True(steque.IsEmpty);
        }

        [Fact]
        public void Pop_FullSteque_Ok()
        {
            var steque = new StequeNodeOf<int>();
            steque.Push(0)
                  .Enqueue(1)
                  .Enqueue(2);

            Assert.Equal(3, steque.Count);

            Assert.Equal(0, steque.Pop());
            Assert.Equal(1, steque.Pop());
            Assert.Equal(2, steque.Pop());
            Assert.True(steque.IsEmpty);
        }

        [Fact]
        public void Pop_NewSteque_Exception()
        {
            var steque = new StequeNodeOf<int>();
            Assert.Throws<InvalidOperationException>(() => steque.Pop());
        }

        [Fact]
        public void Push_NewSteque_Ok()
        {
            var steque = new StequeNodeOf<int>();
            steque.Push(0)
                  .Push(1)
                  .Push(2);

            Assert.False(steque.IsEmpty);
            Assert.Equal(3, steque.Count);
        }
    }
}
