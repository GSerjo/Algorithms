using System;
using System.Collections.Generic;
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

        [Fact]
        public void Reverse()
        {
            var linkedList = new LinkedListNodeOf<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            linkedList.Reverse();

            Assert.Equal(new[] { 3, 2, 1 }, linkedList.ToEnumerable());
        }

        [Fact]
        public void Addition()
        {
            var first = new LinkedList<int>();
            first.AddFirst(7);
            first.AddFirst(0);
            first.AddFirst(0);
            first.AddFirst(1);

            var secod = new LinkedList<int>();
            secod.AddFirst(3);
            secod.AddFirst(9);

            LinkedList<int> result = Addition(first, secod);

            Assert.Equal(new[] { 1, 1, 0, 0 }, result);
        }

        private static LinkedList<int> Addition(LinkedList<int> first, LinkedList<int> second)
        {
            int leadingZeros = first.Count - second.Count;

            if (leadingZeros > 0)
            {
                AddLeadingZeros(second, leadingZeros);
            }
            else if (leadingZeros < 0)
            {
                AddLeadingZeros(first, Math.Abs(leadingZeros));
            }
            var result = new LinkedList<int>();
            var memory = 0;

            LinkedListNode<int> current1 = first.Last;
            LinkedListNode<int> current2 = second.Last;
            while (current1 != null && current2 != null)
            {
                int additon = current1.Value + current2.Value + memory;
                if (additon >= 10)
                {
                    additon = additon % 10;
                    memory = 1;
                }
                else
                {
                    memory = 0;
                }
                result.AddFirst(additon);
                current1 = current1.Previous;
                current2 = current2.Previous;
            }
            return result;
        }

        private static void AddLeadingZeros(LinkedList<int> value, int zeroCount)
        {
            for (var i = 0; i < zeroCount; i++)
            {
                value.AddFirst(0);
            }
        }
    }
}
