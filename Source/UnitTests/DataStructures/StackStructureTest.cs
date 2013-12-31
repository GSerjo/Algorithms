using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Algorithms.DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public sealed class StackStructureTest
    {
        [Fact]
        public void PerformanceTest()
        {
            List<int> data = Enumerable.Range(0, 1000000).ToList();
            var originalStack = new Stack<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            data.ForEach(originalStack.Push);
            stopwatch.Stop();
            Console.WriteLine("Original Stack {0} ms", stopwatch.Elapsed.TotalMilliseconds);

            var myStack = new StackStructure<int>();
            stopwatch = Stopwatch.StartNew();
            data.ForEach(myStack.Push);
            stopwatch.Stop();
            Console.WriteLine("My Stack {0} ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        [Fact]
        public void StackStructure()
        {
            var stack = new StackStructure<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Throws(typeof(IndexOutOfRangeException), () => stack.Pop());
        }
    }
}
