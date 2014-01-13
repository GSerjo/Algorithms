using System;
using Algorithms.DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public sealed class DoublyLinkedListStructureTest
    {
        [Fact]
        public void AddFirst()
        {
            var linkedList = new DoublyLinkedListStructure<int>();
            linkedList
                .AddFirst(0)
                .AddFirst(1)
                .AddFirst(2);
            Assert.Equal(3, linkedList.Count);
            Assert.Equal("{2;1;0;}", linkedList.ToString());
            Console.WriteLine(linkedList.ToString());
        }
    }
}
