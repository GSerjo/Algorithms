<Query Kind="Program" />

void Main()
{
	var array = new[] {4, 5, 6, 7, 1, 2};
	Rotate(array);
	
	array.Dump();
}

private void Rotate(int[] array)
{
	if (array == null || array.Length == 0)
	{
		return;
	}
	for (int i = 0; i < array.Length; i++)
	{
		var min = FindMinIndex(array, i, array.Length);
		Rotate(array, i, min);
	}
}

private int FindMinIndex(int[] array, int lo, int hi)
{
	if (lo == hi)
	{
		return array[lo];
	}
	var result = lo;
	for (int i = lo; i < hi; i++)
	{
		if (array[i] < array[result])
		{
			result = i;
		}
	}
	return result;
}

private void Rotate(int[] array, int lo, int hi)
{
	while (lo < hi)
	{
		var dummy = array[lo];
		array[lo] = array[hi];
		array[hi] = dummy;
		lo++;
		hi--;
	}
}