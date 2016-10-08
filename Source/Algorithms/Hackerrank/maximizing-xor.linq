<Query Kind="Program" />

// https://www.hackerrank.com/challenges/maximizing-xor

void Main()
{
	MaxXor(10, 15).Dump();
}

static int MaxXor(int left, int right)
{
	int xor = left ^ right;

	int i = 0;
	while (((1 << i) - 1) < xor)
	{
		i++;
	}
	int result = (1 << i) - 1;
	return result;
}
