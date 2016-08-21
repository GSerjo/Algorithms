<Query Kind="Program" />

void Main()
{
	Count(5).Dump();
	Count(10).Dump();
	Count(100).Dump();
}

private static int Count(int value)
{
	Convert.ToString(value, 2).Dump();

	var result = 0;
	for (int i = 0; i < 8; i++)
	{
		if ((value & 1) == 1)
		{
			result++;
		}
		value = value >> 1;
	}
	return result;
}

