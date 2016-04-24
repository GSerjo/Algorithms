namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class GraphCyclePath
    {
        private readonly bool[] _marked;

        public GraphCyclePath(Graph graph)
        {
            _marked = new bool[graph.VertexCount];
            Dfs(graph, 0, 0);
        }

        public bool HasCycle { get; private set; }

        private void Dfs(Graph graph, int current, int past)
        {
            _marked[current] = true;

            foreach (int vertex in graph.Adjacent(current))
            {
                if (_marked[vertex] && vertex != past)
                {
                    HasCycle = true;
                    return;
                }
                else if (_marked[vertex])
                {
                    continue;
                }
                Dfs(graph, vertex, current);
            }
        }
    }
}
