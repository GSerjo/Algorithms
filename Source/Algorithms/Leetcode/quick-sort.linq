<Query Kind="Program" />

// quick sort (simple version)

private static Random _random = new Random();

void Main()
{
	// The array should be even
	Sort(new List<int> {1, 0, 3, 2}).Dump();
}


private static List<int> Sort(List<int> array)
{
	if(array == null || array.Count == 0)
	{
		return Enumerable.Empty<int>().ToList();
	}
	if(array.Count == 2)
	{
		if(array[0] < array[1])
		{
			return new List<int> {array[0], array[1]};
		}
		return new List<int> {array[1], array[0]};
	}
	var pivot = _random.Next(0, array.Count);
	var less = array.Where(x => x < pivot).ToList();
	var greater = array.Where(x => x > pivot).ToList();
	var result = new List<int>();
	result.AddRange(Sort(less));
	result.Add(pivot);
	result.AddRange(Sort(greater));
	
	return result;	
}