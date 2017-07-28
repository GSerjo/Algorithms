<Query Kind="Program" />

void Main()
{
	GetSum(3, 4).Dump();
}

private static int GetSum(int a, int b)
{
	while (b != 0)
	{
		int c = a & b;
		c.Dump();
		a = a ^ b;
		a.Dump();
		b = c << 1;
	}

	return a;
}
