<Query Kind="Program" />

void Main()
{
	Fib0(10000000).Dump();
}

private static int Fib0(int n)
{
	if (n <= 1)
	{
		return n;
	}
	int dummy0 = 0;
	int dummy1 = 1;
	
	for (int i = 2; i < n; i++)
	{
		int fib = dummy0 + dummy1;
		dummy0 = dummy1;
		dummy1 = fib;
	}
	return dummy0 + dummy1;
}
