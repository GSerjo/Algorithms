<Query Kind="Program" />

void Main()
{
	HammingWeight(11).Dump();
}

private static int HammingWeight(uint n)
{
	var result = 0;
	while (n != 0)
	{
		if ((n & 1) == 1)
		{
			result++;
		}
		n = n >> 1;
	}
	return result;
}
