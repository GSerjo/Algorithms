<Query Kind="Program" />

//Selection sort

void Main()
{
	Sort(new[] {1, 3, 2, 4}).Dump();
	Sort(new[] {4, 3, 2, 1}).Dump();
	Sort(new[] {1, 2, 3, 4}).Dump();
}

private static int[] Sort(int[] array)
{
	if (array == null || array.Length == 0)
	{
		return array;
	}
	for (int i = 0; i < array.Length; i++)
	{
		var min = i;
		for (int j = i; j < array.Length; j++)
		{
			if (array[j] < array[min])
			{
				min = j;
			}
		}
		var temp = array[i];
		array[i] = array[min];
		array[min] = temp;
	}
	return array;
}
