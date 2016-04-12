using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class SymbolTableTests
    {
        [Fact]
        public void Get()
        {
            var symbolTable = new SymbolTable<int, string>();

            symbolTable.Put(1, "a");
            symbolTable.Put(2, "b");

            Assert.Equal("a", symbolTable.Get(1));

            symbolTable.Put(1, "c");

            Assert.Equal("c", symbolTable.Get(1));

            Assert.Equal(null, symbolTable.Get(10));
        }
    }
}