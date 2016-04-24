using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.DataStructures;
using Xunit;

namespace UnitTests.RobertSedgewick.DataStructures
{
    public sealed class DepthFirstPathsTests
    {
        [Fact]
        public void PathTo()
        {
            Graph graph = Create(@"DataStore\tinyCG.txt");
            var path = new DepthFirstPaths(graph, 0);
            IEnumerable<int> actual = path.PathTo(4);
            Assert.Equal(new[] { 0, 5, 3, 2, 4 }, actual);
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
