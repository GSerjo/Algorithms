using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class Graph
    {
        private readonly List<int>[] _adj;

        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
            _adj = new List<int>[vertexCount];
            for (var i = 0; i < vertexCount; i++)
            {
                _adj[i] = new List<int>();
            }
        }

        public int EdgeCount { get; private set; }
        public int VertexCount { get; }

        public void AddEdge(int vertexOne, int vertexSecond)
        {
            _adj[vertexOne].Add(vertexSecond);
            _adj[vertexSecond].Add(vertexOne);
            EdgeCount++;
        }

        public IEnumerable<int> Adj(int vertex)
        {
            return _adj[vertex];
        }
    }
}
