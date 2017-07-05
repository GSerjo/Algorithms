<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "8.7.1.txt"));
	
	var count = int.Parse(lines.First());
	//var count = int.Parse(Console.ReadLine());
	
	var items = lines.Last().Split(' ').Select(int.Parse).ToList();
	//var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
	
	items.Dump();
	
	Console.WriteLine(Count(items));
}

private static int Count(List<int> items)
{
	if (items.Count == 1)
	{
		return items[0];
	}
	if (items.Count == 2)
	{
		var a = items[0];
		var b = items[1];
		if (a < 0 && b < 0)
		{
			return b;
		}
		if (a < 0 && b >= 0)
		{
			return b;
		}
		return items.Sum();
	}
	var result = 0;
	
	var dummy2 = items[0];
	var dummy1 = Max(dummy2, items[1]);

	for (int i = 2; i < items.Count; i++)
	{
		result = items[i] + Math.Max(dummy1, dummy2);
		dummy2 = dummy1;
		dummy1 = result;
	}
	return result;
}

private static int Max(int a, int b)
{
	if (a >= 0 && b >= 0)
	{
		return a + b;
	}
	return b;
}