<Query Kind="Program" />

/*

Merge sort (simple version)

*/

void Main()
{
	// The array should be even
	Sort(new List<int> {1, 0, 3, 2, 5, 7, 8, 9}).Dump();
}

private static List<int> Sort(List<int> array)
{
	if (array == null || array.Count == 0)
	{
		return new List<int>();
	}
	if (array.Count == 1)
	{
		return array;
	}
	if (array.Count == 2)
	{
		if (array[0] < array[1])
		{
			return new List<int> { array[0], array[1] };
		}
		return new List<int> { array[1], array[0] };
	}
	var left = new List<int>();
	var right = new List<int>();
	var mid = array.Count/2;
	var result = new List<int>();
	left.AddRange(Sort(array.Take(mid).ToList()));
	left.AddRange(Sort(array.Skip(mid).ToList()));
	var i = 0;
	while (left.Count != 0 && right.Count != 0)
	{
		if (left[i] < right[i])
		{
			result.Add(left[i]);
		}
		else
		{
			result.Add(right[i]);
		}
	}
	if (left.Count == 0)
	{
		result.AddRange(right);
	}
	else
	{
		result.AddRange(left);
	}
	return result;
}