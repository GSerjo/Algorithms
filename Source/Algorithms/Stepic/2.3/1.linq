<Query Kind="Program" />

void Main()
{
	Gcd(18, 35).Dump();
}

private static long Gcd(long a, long b)
{
	while (true)
	{
		if (a == 0)
		{
			return b;
		}
		if (b == 0)
		{
			return a;
		}
		if (a > b)
		{
			a = a % b;
		}
		else
		{
			b = b % a;
		}
	}
}
