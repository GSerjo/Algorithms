<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "8.2.txt"));
	
	var length = int.Parse(lines.First());
	//var length = int.Parse(Console.ReadLine());
	
	var items = lines.Last().Split(' ').Select(int.Parse).ToList();
	//var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
	
	
	var cache = new int[items.Count];
	for (int i = 0; i < cache.Length; i++)
	{
		cache[i] = 1;
	}
	
	for (int i = 1; i < items.Count; i++)
	{
		for (int j = i - 1; j >= 0; j--)
		{
			if (items[i] < items[j])
			{
				continue;
			}
			if (items[i] % items[j] == 0)
			{
				cache[i] = Math.Max(cache[i], cache[j] + 1);
			}
		}
	}
	
	var result = cache.Max();
	
	Console.WriteLine(result);
}
