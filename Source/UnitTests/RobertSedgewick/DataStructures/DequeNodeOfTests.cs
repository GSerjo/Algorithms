using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class DequeNodeOfTests
    {
        [Fact]
        public void IsEmpty_NewDeque_True()
        {
            var deque = new DequeNodeOf<int>();
            Assert.True(deque.IsEmpty);
            Assert.Equal(0, deque.Count);
        }

        [Fact]
        public void PopLeft_FullDeque_Ok()
        {
            var deque = new DequeNodeOf<int>();
            deque.PushLeft(0)
                 .PushLeft(1)
                 .PushLeft(2);

            Assert.Equal(2, deque.PopLeft());
            Assert.Equal(1, deque.PopLeft());
            Assert.Equal(1, deque.Count);
            Assert.False(deque.IsEmpty);
            Assert.Equal(0, deque.PopLeft());
            Assert.True(deque.IsEmpty);
        }

        [Fact]
        public void PopLeft_NewDeque_Exception()
        {
            var deque = new DequeNodeOf<int>();
            Assert.Throws<InvalidOperationException>(() => deque.PopLeft());
        }

        [Fact]
        public void PopRight_FullDeque_Ok()
        {
            var deque = new DequeNodeOf<int>();
            deque.PushLeft(0)
                 .PushLeft(1)
                 .PushLeft(2);

            Assert.Equal(0, deque.PopRight());
            Assert.Equal(1, deque.PopRight());
            Assert.Equal(1, deque.Count);
            Assert.False(deque.IsEmpty);
            Assert.Equal(2, deque.PopRight());
            Assert.True(deque.IsEmpty);
        }

        [Fact]
        public void PopRigth_NewDeque_Exception()
        {
            var deque = new DequeNodeOf<int>();
            Assert.Throws<InvalidOperationException>(() => deque.PopRight());
        }

        [Fact]
        public void PushLeft_NewDeque_Ok()
        {
            var deque = new DequeNodeOf<int>();
            deque.PushLeft(0)
                 .PushLeft(1)
                 .PushLeft(2);

            Assert.False(deque.IsEmpty);
            Assert.Equal(3, deque.Count);
        }

        [Fact]
        public void PushRigth_NewDeque_Ok()
        {
            var deque = new DequeNodeOf<int>();
            deque.PushRight(0)
                 .PushRight(1)
                 .PushRight(2);

            Assert.False(deque.IsEmpty);
            Assert.Equal(3, deque.Count);
        }
    }
}
