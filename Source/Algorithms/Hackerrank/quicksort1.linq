<Query Kind="Program" />

// https://www.hackerrank.com/challenges/quicksort1

void Main()
{
	Console.ReadLine();
	var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//	var array = new[]{4, 5, 3, 7, 2};
	Partition(array).Dump();
}

private static string Partition(int[] array)
{
	if(array == null || array.Length == 0)
	{
		return string.Empty;
	}
	if(array.Length == 1)
	{
		return array[0].ToString();
	}
	var left = new List<int>();
	var right = new List<int>();
	var equal = new List<int>();
	equal.Add(array[0]);
	for (int i = 1; i < array.Length; i++)
	{
		if(array[i] == array[0])
		{
			equal.Add(array[i]);
		}
		else if(array[i] < array[0])
		{
			left.Add(array[i]);
		}
		else
		{
			right.Add(array[i]);
		}
	}
	left.AddRange(equal);
	left.AddRange(right);
	return string.Join(" ", left);
}