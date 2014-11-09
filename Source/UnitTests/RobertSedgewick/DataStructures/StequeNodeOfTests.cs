using System;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class StequeNodeOfTests
    {
        [Fact]
        public void IsEmpty_NewSteque_True()
        {
            var steque = new StequeNodeOf<int>();
            Assert.True(steque.IsEmpty);
        }
    }
}
