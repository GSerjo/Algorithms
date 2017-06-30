<Query Kind="Program" />

void Main()
{
	Console.ReadLine();
	
	var source = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
	Console.WriteLine(string.Join(" ", Sort(source)));
}

private static int[] Sort(int[] source)
{
	if(source == null || source.Length == 0)
	{
		return new int[0];
	}
	var count = new int[11];
	var result = new int[source.Length];
	
	foreach (var item in source)
	{
		count[item]++;
	}
	
	for (int i = 1; i < count.Length; i++)
	{
		count[i] += count[i-1];
	}
	
	for (int i = source.Length - 1; i >=0; i--)
	{
		result[count[source[i]] - 1] = source[i];
		count[source[i]] -= 1;
	}
	return result;
}