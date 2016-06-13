<Query Kind="Program" />

// https://www.hackerrank.com/challenges/bfsshortreach

//private static int _fileLine = 0;
private const int EdgeLength = 6;
private const int EdgeUnreachable = -1;

void Main()
{
	var testCount = int.Parse(Console.ReadLine());
//	var testCount = int.Parse(Input.Line(0));
	var result = new List<string>();
	for (int i = 0; i < testCount; i++)
	{
		var graphInfo = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//		var graphInfo = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
		var graph = CreateGraph(graphInfo);
		
		int startPoint = int.Parse(Console.ReadLine());
//		int startPoint = int.Parse(Input.Line(++_fileLine));
		var pathes = CalculateShortPath(startPoint, graph);
		result.Add(string.Join(" ",pathes));
	}
	result.ForEach(x=>Console.WriteLine(x));
}

private static List<int> CalculateShortPath(int startPoint, Graph graph)
{
	var path = new Dictionary<int, int>();
	var visited = new HashSet<int>();
	var queue = new Queue<Vertex>();
	
	queue.Enqueue(new Vertex(startPoint, 0));
	visited.Add(startPoint);
	
	while (queue.Count != 0)
	{
		Vertex currentVertex = queue.Dequeue();
		path.Add(currentVertex.Id, currentVertex.Level);

		foreach (var vertex in graph.Adjacent(currentVertex.Id))
		{
			if (visited.Contains(vertex))
			{
				continue;
			}
			visited.Add(vertex);
			queue.Enqueue(new Vertex(vertex, currentVertex.Level + 1));
		}
	}
	
	var result = new List<int>();
	for (int i = 1; i <= graph.VertexCount; i++)
	{
		if(i == startPoint)
		{
			continue;
		}
		if(path.ContainsKey(i))
		{
			result.Add(path[i]*EdgeLength);
		}
		else
		{
			result.Add(EdgeUnreachable);
		}
	}
	
	return result;
}

private struct Vertex
{
	public Vertex(int id, int level)
	{
		Id = id;
		Level = level;
	}

	public int Id { get; private set; }
	public int Level { get; private set; }
}

private static Graph CreateGraph(int[] graphInfo)
{
	var result = new Graph(graphInfo[0]);
	
	for (int i = 0; i < graphInfo[1]; i++)
	{
		var graphLine = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//		var graphLine = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
		result.Add(graphLine[0], graphLine[1]);
	}
	
	return result;
}

private sealed class Graph
{
	private List<int>[] _adj;
	public Graph(int vertexCount)
	{
		VertexCount = vertexCount;
		_adj = new List<int>[vertexCount + 1];
		for (int i = 1; i <= vertexCount; i++)
		{
			_adj[i] = new List<int>();
		}
	}
	
	public int VertexCount {get; private set;}

	public void Add(int u, int v)
	{
		_adj[u].Add(v);
	}
	
	public List<int> Adjacent(int vertex)
	{
		return _adj[vertex].ToList();
	}
}
