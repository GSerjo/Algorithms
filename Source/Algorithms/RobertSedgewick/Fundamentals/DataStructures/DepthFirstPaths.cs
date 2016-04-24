using System.Collections.Generic;
using System.Linq;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class DepthFirstPaths
    {
        private readonly int _sourceVertex;
        private readonly bool[] _marked;
        private readonly int[] _edgeTo;

        public DepthFirstPaths(Graph graph, int sourceVertex)
        {
            _sourceVertex = sourceVertex;
            _marked = new bool[graph.VertexCount];
            _edgeTo = new int[graph.VertexCount];
            DepthFirstSearch(graph, sourceVertex);
        }

        private void DepthFirstSearch(Graph graph, int vertex)
        {
            _marked[vertex] = true;
            foreach (int w in graph.Adjacent(vertex))
            {
                if (_marked[w])
                {
                    continue;
                }
                _edgeTo[w] = vertex;
                DepthFirstSearch(graph, w);
            }
        }

        public bool HasPathTo(int vertex)
        {
            return _marked[vertex];
        }

        public IEnumerable<int> PathTo(int vertex)
        {
            if (!HasPathTo(vertex))
            {
                return Enumerable.Empty<int>();
            }
            var result = new Stack<int>();
            while (_sourceVertex != vertex)
            {
                result.Push(vertex);
                vertex = _edgeTo[vertex];
            }
            result.Push(_sourceVertex);
            return result;
        }

    }
}
