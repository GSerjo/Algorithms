<Query Kind="Program" />

void Main()
{
	HammingDistance(1, 4).Dump();
}

private static int HammingDistance(int x, int y)
{
	if (x == y)
	{
		return 0;
	}
	var result = 0;
	while (x != 0 || y != 0)
	{
		if ((x & 1) != (y & 1))
		{
			result++;
		}
		x = x >> 1;
		y = y >> 1;
	}
	return result;
}
