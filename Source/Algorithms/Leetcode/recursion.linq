<Query Kind="Program" />

// recursion

void Main()
{
	Sum(new[] {1, 2, 3}).Dump();
	Count(new[] {1, 2, 3}).Dump();
	Greatest(new[] {1, 4, 3}).Dump();
}

private static int Sum(int[] array)
{
	if(array == null || array.Length == 0)
	{
		return 0;	
	}
	if(array.Length == 1)
	{
		return array[0];
	}
	return array.First() + Sum(array.Skip(1).ToArray());
}


private static int Count(int[] array)
{
	if(array == null || array.Length == 0)
	{
		return 0;
	}
	if(array.Length == 1)
	{
		return 1;
	}
	return 1 + Count(array.Skip(1).ToArray());
}

private static int Greatest(int[] array)
{
	if (array == null || array.Length == 0)
	{
		return 0;
	}
	if(array.Length == 1)
	{
		return array[0];
	}
	if(array.Length == 2)
	{
		return Math.Max(array[0], array[1]);
	}
	return Math.Max(array[0], Greatest(array.Skip(1).ToArray()));
}