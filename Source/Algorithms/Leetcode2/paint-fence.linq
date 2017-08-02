<Query Kind="Program" />

void Main()
{
	NumWays(3, 2).Dump();
}

private static int NumWays(int n, int k)
{
	if (n == 0)
	{
		return 0;
	}
	if (n == 1)
	{
		return k;
	}
	var same = k;
	var different = k * (k - 1);
	
	for (int i = 2; i < n; i++)
	{
		var dummy = different;
		different = (same + different) * (k - 1);
		same = dummy;
	}
	return same + different;
}
