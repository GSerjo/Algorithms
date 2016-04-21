using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class Graph
    {
        private readonly List<int>[] _adj;

        public Graph(int vertex)
        {
            _adj = new List<int>[vertex];
            for (var i = 0; i < vertex; i++)
            {
                _adj[i] = new List<int>();
            }
        }

        public int EdgeCount { get; private set; }

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
