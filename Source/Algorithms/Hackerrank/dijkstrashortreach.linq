<Query Kind="Program" />

//https://www.hackerrank.com/challenges/dijkstrashortreach

private static int _fileLine = 0;
private const int VertexUnreachable = -1;

void Main()
{
	var testCount = int.Parse(Console.ReadLine());
//	var testCount = int.Parse(Input.Line(0));
	
	var result = new List<string>();
	
	for (int i = 0; i < testCount; i++)
	{
		var graphInfo = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
//		var graphInfo = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
		var graph = CreateGraph(graphInfo);

		int startPoint = int.Parse(Console.ReadLine());
//		int startPoint = int.Parse(Input.Line(++_fileLine));
		var pathes = CalculateShortPath(startPoint, graph);
		result.Add(string.Join(" ", pathes));
	}
	
	result.ForEach(x=>Console.WriteLine(x));
}

private static List<int> CalculateShortPath(int startPoint, Graph graph)
{
	var distTo = new int[graph.VertexCount + 1];
	
	for (int i = 1; i <= graph.VertexCount; i++)
	{
		distTo[i] = int.MaxValue;
	}
	distTo[startPoint] = 0;
	
	var queue =new Dictionary<int, Item>();
	queue.Add(startPoint, new Item { Id = startPoint, Distance = 0});
	
	while (queue.Count != 0)
	{
		var pair = queue.Values.OrderBy(x=>x.Distance).First();
		queue.Remove(pair.Id);

		foreach (Edge edge in graph.Adjacent(pair.Id))
		{
			var to = edge.To;
			
			if(distTo[to] > distTo[edge.From] + edge.Length)
			{
				distTo[to] = distTo[edge.From] + edge.Length;
				queue[to] = new Item { Id = to, Distance = distTo[to]};
			}
		}
		
	}
	var result = new List<int>();

	for (int i = 1; i < distTo.Length; i++)
	{
		if(i == startPoint)
		{
			continue;
		}
		else if(distTo[i] == int.MaxValue)
		{
			result.Add(VertexUnreachable);
		}
		else
		{
			result.Add(distTo[i]);
		}
	}
	
	return result;
}

private struct Item
{
	public int Id { get; set; }
	public int Distance { get; set; }
}


private static Graph CreateGraph(int[] graphInfo)
{
	var result = new Graph(graphInfo[0]);

	for (int i = 0; i < graphInfo[1]; i++)
	{
		var line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
//		var line = Input.Line(++_fileLine).Split(' ').Select(x=>int.Parse(x)).ToArray();
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
		_adj[to].Add(new Edge {From = to, To = from, Length = length});
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