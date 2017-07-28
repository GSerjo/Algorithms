<Query Kind="Program" />

void Main()
{
	IntToString(10).Dump();
}

private static string IntToString(int value)
{
	if (value < 10)
	{
		return value.ToString();
	}
	var result = new StringBuilder();
	
	while (value != 0)
	{
		result.Insert(0, value % 10);
		value /= 10;
	}
	return result.ToString();
}
