<Query Kind="Program" />

void Main()
{
	//var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "8.4.txt"));
	
	//var counts = lines.First().Split(' ');
	var counts = Console.ReadLine().Split(' ');
	
	var w = int.Parse(counts[0]);
	var n = int.Parse(counts[1]);
	
	//var itemsLine = lines.Last();
	var itemsLine = Console.ReadLine();
	var items = itemsLine.Split(' ').Select(int.Parse).ToList();
	
	Console.WriteLine(Count(w, items));
	
}

private static int Count(int w, List<int> items)
{
	if (w == 0 || items.Count == 0)
	{
		return 0;
	}
	
	var matrix = new int[w + 1, items.Count +1];
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		matrix[i, 0] = 0;
	}
	
	for (int i = 0; i < matrix.GetLength(1); i++)
	{
		matrix[0, i] = 0;
	}
	
	for (int i = 1; i <= items.Count; i++)
	{
		for (int wj = 1; wj <= w; wj++)
		{
			matrix[wj, i] = matrix[wj, i - 1];

			if (items[i - 1] <= wj)
			{
				matrix[wj, i] = Math.Max(matrix[wj, i], matrix[wj - items[i - 1], i - 1] + items[i - 1]);
			}
		}
	}
	return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
}

