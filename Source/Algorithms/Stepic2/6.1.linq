<Query Kind="Program" />

void Main()
{
	//var line1 = Console.ReadLine();
	//var line2 = Console.ReadLine();
	
	var line1 = "5 1 5 8 12 13";
	var line2 = "5 8 1 23 1 11";
	
	var data = Convert(line1.Split(' '));
	var search = Convert(line2.Split(' '));
	var result = new List<long>();
	
	foreach (var item in search)
	{
		result.Add(Search(data, item));
	}
	Console.WriteLine(string.Join(" ", result));
}

private static List<long> Convert(string[] items)
{
	var result = new List<long>();
	for (int i = 0; i < items.Length; i++)
	{
		if(i == 0)
		{
			continue;
		}
		result.Add(long.Parse(items[i]));
	}
	return result;
}

private static long Search(List<long> data, long search)
{
	if(data == null || data.Count == 0)
	{
		return -1;
	}
	if(data.Count == 1)
	{
		return data[0] == search ? 0 : -1;
	}
	var lo = 0;
	var hi = data.Count - 1;
	while (lo <= hi)
	{
		var mid = lo + (hi - lo)/2;
		if(data[mid] == search)
		{
			return mid + 1;
		}
		if(data[mid] > search)
		{
			hi = mid - 1;
		}
		else
		{
			lo = mid + 1;
		}
	}
	return -1;
}