<Query Kind="Program" />

void Main()
{
	CountWays(3).Dump();
	CountWays(4).Dump();
}

private static int CountWays(int n)
{
	if (n == 0 || n == 1)
	{
		return 1;
	}
	if (n == 2)
	{
		return 2;
	}
	var dummy0 = 1;
	var dummy1 = 1;
	var dummy2 = 2;
	for (int i = 3; i < n; i++)
	{
		var result = dummy0 + dummy1 + dummy2;
		dummy0 = dummy1;
		dummy1 = dummy2;
		dummy2 = result;
	}
	return dummy0 + dummy1 + dummy2;	
}