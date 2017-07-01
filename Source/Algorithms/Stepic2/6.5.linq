<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "6.5.txt"));
	
	var numbers = lines.First().Split(' ');
	var segmentCount = int.Parse(numbers[0]);
	var pointCount = int.Parse(numbers[1]);
	
	var segments = new List<Segment>();
	
	for (int i = 0; i < segmentCount; i++)
	{
		var line = lines[i + 1].Split(' ');
//		var line = Console.ReadLine().Split(' ');
		
		segments.Add(new Segment { Start = long.Parse(line[0]), End = long.Parse(line[1]) });
	}
	
	var points = lines[lines.Length - 1]
					.Split(' ')
					.Select((x, i) => new Point { Order = i, Value = long.Parse(x)}).ToList();
	
	lines.Dump();
}

private static List<int> Count(List<Segment> segments, List<Point> points)
{
	
}

private struct Point
{
	public int Order;
	public long Value;
}

private struct Segment
{
	public long Start;
	public long End;
}

