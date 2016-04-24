using System.Collections.Generic;
using System.Linq;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class BreadthFirstPaths
    {
        private readonly int[] _edgeTo;
        private readonly bool[] _marked;
        private readonly int _sourceVertex;

        public BreadthFirstPaths(Graph graph, int sourceVertex)
        {
            _sourceVertex = sourceVertex;
            _marked = new bool[graph.VertexCount];
            _edgeTo = new int[graph.VertexCount];
            Bfs(graph, sourceVertex);
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

        private void Bfs(Graph graph, int vertex)
        {
            _marked[vertex] = true;
            var queue = new Queue<int>();
            queue.Enqueue(vertex);
            while (queue.Count != 0)
            {
                vertex = queue.Dequeue();
                foreach (int adjacentVertex in graph.Adjacent(vertex))
                {
                    _marked[adjacentVertex] = true;
                    _edgeTo[adjacentVertex] = vertex;
                    queue.Enqueue(adjacentVertex);
                }
            }
        }
    }
}
