<Query Kind="Program" />

void Main()
{
	FibLastDigit(12).Dump();
}

private static int FibLastDigit(int n)
{
	if (n <= 1)
	{
		return n;
	}
	int dummy0 = 0;
	int dummy1 = 1;

	for (int i = 2; i < n; i++)
	{
		int lastDigit = (dummy0 + dummy1) % 10;
		dummy0 = dummy1;
		dummy1 = lastDigit;
	}
	return (dummy0 + dummy1) % 10;
}
