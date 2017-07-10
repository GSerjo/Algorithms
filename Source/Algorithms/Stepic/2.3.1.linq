<Query Kind="Program" />

void Main()
{
	
	//Console.ReadLine();
	//var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
	
	var items = "7 6 5 4 3 2".Split(' ').Select(int.Parse).ToList();
	
	var result = Permutations(items);
	Console.WriteLine(result.Count);
	
	result.ForEach(Console.WriteLine);
}

private static List<string> Permutations(List<int> items)
{
	if (items.Count == 1)
	{
		return new List<string>();
	}
	var result = new List<string>();
	
	for (int i = items.Count/2 - 1; i >= 0; i--)
	{
		Sink(i, items, result);
	}	
	return result;
}

private static void Sink(int index, List<int> items, List<string> result)
{
	while (index * 2 < items.Count)
	{
		int i = index == 0 ? 1 : index * 2 + 1;
		if (i < items.Count - 1 && items[i] > items[i + 1])
		{
			i++;
		}
		if (items[index] > items[i])
		{
			Swap(index, i, items);
			result.Add($"{index} {i}");
			index = i;
		}
		else
		{
			break;
		}
	}
}

private static void Swap(int i, int j, List<int> items)
{
	var dummy = items[i];
	items[i] = items[j];
	items[j] = dummy;
}