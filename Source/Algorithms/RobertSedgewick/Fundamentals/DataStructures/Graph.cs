using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class Graph
    {
        private readonly List<int>[] _adjacent;

        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
            _adjacent = new List<int>[vertexCount];
            for (var i = 0; i < vertexCount; i++)
            {
                _adjacent[i] = new List<int>();
            }
        }

        public int EdgeCount { get; private set; }
        public int VertexCount { get; }

        public void AddEdge(int vertexOne, int vertexSecond)
        {
            _adjacent[vertexOne].Add(vertexSecond);
            _adjacent[vertexSecond].Add(vertexOne);
            EdgeCount++;
        }

        public IEnumerable<int> Adjacent(int vertex)
        {
            return _adjacent[vertex];
        }
    }
}
