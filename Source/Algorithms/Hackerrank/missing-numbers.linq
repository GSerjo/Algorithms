<Query Kind="Program" />

//https://www.hackerrank.com/challenges/missing-numbers

void Main()
{
	Console.ReadLine();	
	var list1 = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToList();
//	var list1 = Input.Line(1).Split(' ').Select(x=>int.Parse(x)).OrderBy(x=>x).ToList();
	var cache1 = CreateCache(list1);
	
	Console.ReadLine();
	var list2 = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToList();
//	var list2 = Input.Line(3).Split(' ').Select(x=>int.Parse(x)).OrderBy(x=>x).ToList();
	var cache2 = CreateCache(list2);
	
	var result = new List<int>();
	foreach (var key in cache2.Keys)
	{
		if(cache1.ContainsKey(key) == false)
		{
			result.Add(key);
		}
		if(cache1[key] != cache2[key])
		{
			result.Add(key);
		}
	}
	Console.WriteLine(string.Join(" ", result.OrderBy(x=>x)));
}

private static Dictionary<int, int> CreateCache(List<int> list)
{
	var result = new Dictionary<int, int>();
	for (int i = 0; i < list.Count; i++)
	{
		if(result.ContainsKey(list[i]))
		{
			result[list[i]]++;
		}
		else
		{
			result[list[i]] = 1;
		}
	}
	return result;
}
