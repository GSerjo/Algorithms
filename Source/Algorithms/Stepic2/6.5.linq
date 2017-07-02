<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "6.5.txt"));
	
	var numbers = lines.First().Split(' ');
	//var numbers = Console.ReadLine().Split(' ');
	
	
	var segmentCount = int.Parse(numbers[0]);
	var pointCount = int.Parse(numbers[1]);
	
	var segments = new List<Segment>();
	
	for (int i = 0; i < segmentCount; i++)
	{
		var line = lines[i + 1].Split(' ');
		//var line = Console.ReadLine().Split(' ');
		
		segments.Add(new Segment { Start = long.Parse(line[0]), End = long.Parse(line[1]) });
	}
	
	var points = lines[lines.Length - 1]
					.Split(' ')
					.Select((x, i) => new Point { Order = i, Value = long.Parse(x)}).ToList();

//	var points = Console.ReadLine()
//				.Split(' ')
//				.Select((x, i) => new Point { Order = i, Value = long.Parse(x) }).ToList();


	Console.WriteLine(string.Join(" ", Count(segments, points)));
}

private static List<int> Count(List<Segment> segments, List<Point> points)
{
	if(segments.Count == 0)
	{
		return new List<int>();
	}
	
	var byValue = points.OrderBy(x=>x.Value).ToList();
	
	UpdateLeftSegmentCount(segments, byValue);
	UpdateRightSegmentCount(segments, byValue);
	
	var result = byValue.OrderBy(x=>x.Order).Select(x=>x.Segments).ToList();
	
	return result;
}

private static void UpdateRightSegmentCount(List<Segment> segments, List<Point> byValue)
{
	var byEnd = segments.OrderBy(x=>x.End).ToList();

	var i = 0;
	var j = 0;

	while (i < byValue.Count && j < byEnd.Count)
	{
		if (byValue[i].Value > byEnd[j].End)
		{
			byValue[i].RightSegments++;
			j++;
		}
		else
		{
			i++;
			if (i < byValue.Count)
			{
				byValue[i].RightSegments = byValue[i - 1].RightSegments;
			}
		}
	}
	if (i < byValue.Count)
	{
		for (int k = i + 1; k < byValue.Count; k++)
		{
			byValue[k].RightSegments = byValue[i].RightSegments;
		}
	}
}

private static void UpdateLeftSegmentCount(List<Segment> segments, List<Point> byValue)
{
	
	var byStart = segments.OrderBy(x=>x.Start).ToList();
	
	var i = 0;
	var j = 0;

	while (i < byValue.Count && j < byStart.Count)
	{
		if (byValue[i].Value < byStart[j].Start)
		{
			i = i + 1;
			if (i < byValue.Count)
			{
				byValue[i].LeftSegments = byValue[i - 1].LeftSegments;
			}
		}
		else
		{
			byValue[i].LeftSegments++;
			j++;
		}
	}
	if (i < byValue.Count)
	{
		for (int k = i + 1; k < byValue.Count; k++)
		{
			byValue[k].LeftSegments = byValue[i].LeftSegments;
		}
	}
}

private class Point
{
	public int Order;
	public long Value;
	public int LeftSegments = 0;
	public int RightSegments = 0;
	
	public int Segments
	{
		get
		{
			return LeftSegments - RightSegments;
		}
	}
	
}

private struct Segment
{
	public long Start;
	public long End;
}