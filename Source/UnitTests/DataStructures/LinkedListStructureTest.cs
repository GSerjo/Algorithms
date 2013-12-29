using System;
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
            Console.WriteLine(linkedList.ToString());
        }
    }
}
