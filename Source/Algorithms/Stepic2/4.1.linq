<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "4.1.txt"));
	
	var count = int.Parse(lines.First());
	//var count = int.Parse(Console.ReadLine());
	
	var segments = new List<Segment>();
	for (int i = 0; i < count; i++)
	{
		var line = lines[i + 1];
		//var line = Console.ReadLine();
		
		var items = line.Split(' ');
		segments.Add(new Segment { Start = int.Parse(items[0]), End = int.Parse(items[1])});
	}
	
	var result = new List<int>();
	
	var byEnd = segments.OrderBy(x=>x.End).ToList();
	Segment current = null;
	foreach (var segment in byEnd)
	{
		if(current == null)
		{
			current = segment;
			result.Add(current.End);
		}
		else
		{
			if(segment.Start <= current.End)
			{
				continue;
			}
			current = segment;
			result.Add(current.End);
		}
	}
	Console.WriteLine(result.Count);
	Console.WriteLine(string.Join(" ", result));
}

private class Segment
{
	public int Start;
	public int End;
}

