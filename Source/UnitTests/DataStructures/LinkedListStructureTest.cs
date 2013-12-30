﻿using System;
using Algorithms.DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public sealed class LinkedListStructureTest
    {
        [Fact]
        public void AddFirst()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddFirst(1)
                .AddFirst(2);
            Assert.Equal(3, linkedList.Count);
            Assert.Equal("{2;1;0;}", linkedList.ToString());
            Console.WriteLine(linkedList.ToString());
        }

        [Fact]
        public void AddFirstAndLast()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddLast(2)
                .AddFirst(1);
            Assert.Equal(3, linkedList.Count);
            Assert.Equal("{1;0;2;}", linkedList.ToString());
        }

        [Fact]
        public void AddLast()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddLast(0)
                .AddLast(1)
                .AddLast(2);
            Assert.Equal(3, linkedList.Count);
            Assert.Equal("{0;1;2;}", linkedList.ToString());
            Console.WriteLine(linkedList.ToString());
        }

        [Fact]
        public void Clear()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddFirst(1);
            linkedList.Clear();
            Assert.Equal(0, linkedList.Count);
        }

        [Fact]
        public void Contains_Absent_False()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddFirst(1)
                .AddFirst(2);
            bool contains = linkedList.Contains(3);
            Assert.False(contains);
        }

        [Fact]
        public void Contains_Exist_True()
        {
            var linkedList = new LinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddFirst(1)
                .AddFirst(2);
            bool contains = linkedList.Contains(1);
            Assert.True(contains);
        }
    }
}
