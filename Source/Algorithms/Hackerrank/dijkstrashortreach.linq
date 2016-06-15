<Query Kind="Program" />

//https://www.hackerrank.com/challenges/dijkstrashortreach

private static int _fileLine = 0;
private const int VertexUnreachable = -1;

void Main()
{
//	var testCount = int.Parse(Console.ReadLine());
	var testCount = int.Parse(Input.Line(0));
	
	var result = new List<string>();
	
	for (int i = 0; i < testCount; i++)
	{
//		var graphInfo = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var graphInfo = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
	}
	
	result.ForEach(x=>Console.WriteLine(x));
}

private static List<int> CalculateShortPath(int startPoint, Graph graph)
{
	var distTo = new int[graph.VertexCount + 1];
	var edgeTo = new Edge[graph.VertexCount + 1];
	
	for (int i = 1; i <= graph.VertexCount; i++)
	{
		distTo[i] = int.MaxValue;
	}
	distTo[startPoint] = 0;
	
	var queue = new SortedDictionary<int, int>();
	queue.Add(startPoint, 0);
	
	while (queue.Count != 0)
	{
		var pair = queue.Values.Min();
		
		foreach (Edge edge in graph.Adjacent(0))
		{
			var to = edge.To;
			
			if(distTo[to] > distTo[edge.From] + edge.Length)
			{
				distTo[to] = distTo[edge.From] + edge.Length;
				edgeTo[to] = edge;
			}
		}
		
	}
	return new List<int>();
}


private static Graph CreateGraph(int[] graphInfo)
{
	var result = new Graph(graphInfo[0]);

	for (int i = 0; i < graphInfo[1]; i++)
	{
//		var line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var line = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
		result.Add(line[0], line[1], line[2]);
	}

	return result;
}


private sealed class Graph
{
	private List<Edge>[] _adj;
	public Graph(int vertexCount)
	{
		VertexCount = vertexCount;
		_adj = new List<Edge>[vertexCount + 1];
		for (int i = 1; i <= vertexCount; i++)
		{
			_adj[i] = new List<Edge>();
		}
	}

	public int VertexCount { get; private set; }

	public void Add(int from, int to, int length)
	{
		_adj[from].Add(new Edge {From = from, To = to, Length = length});
	}

	public List<Edge> Adjacent(int vertex)
	{
		return _adj[vertex].ToList();
	}
}


private sealed class Edge
{
	public int From { get; set; }
	public int To { get; set; }
	public int Length { get; set; }
}

private static class Input
{
	private static string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private static string[] _data;

	static Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public static string Line(int index)
	{
		return _data[index];
	}
}