<Query Kind="Program" />

void Main()
{
	IsPowerOfTwo(8).Dump();
	IsPowerOfTwo(7).Dump();
	IsPowerOfTwo(1).Dump();
}

private static bool IsPowerOfTwo(int n)
{
	if (n <= 0)
	{
		return false;
	}
	return (n & (n - 1)) == 0;
}
