<Query Kind="Program" />

//https://www.hackerrank.com/challenges/dijkstrashortreach
void Main()
{
	
}




private sealed class Graph
{
	private List<Vertex>[] _adj;
	public Graph(int vertexCount)
	{
		VertexCount = vertexCount;
		_adj = new List<Vertex>[vertexCount + 1];
		for (int i = 1; i <= vertexCount; i++)
		{
			_adj[i] = new List<Vertex>();
		}
	}

	public int VertexCount { get; private set; }

	public void Add(int from, int to, int length)
	{
		_adj[from].Add(new Vertex {From = from, To = to, Length = length});
	}

	public List<Vertex> Adjacent(int vertex)
	{
		return _adj[vertex].ToList();
	}
}


private sealed class Vertex
{
	public int From { get; set; }
	public int To { get; set; }
	public int Length { get; set; }
}