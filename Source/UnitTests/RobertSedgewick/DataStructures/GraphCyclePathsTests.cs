using System.IO;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class GraphCyclePathsTests
    {
        [Fact]
        public void PathTo()
        {
            Graph graph = Create(@"DataStore\tinyCG.txt");
            var path = new GraphCyclePaths(graph);
            Assert.True(path.HasCycle);
        }

        private static Graph Create(string filePath)
        {
            int vertexCount = int.Parse(File.ReadLines(filePath).First());
            var result = new Graph(vertexCount);
            foreach (string line in File.ReadLines(filePath).Skip(2))
            {
                string[] vertexes = line.Split(null);
                result.AddEdge(int.Parse(vertexes[0]), int.Parse(vertexes[1]));
            }
            return result;
        }
    }
}
