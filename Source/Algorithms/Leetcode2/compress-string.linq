<Query Kind="Program" />

void Main()
{
	Compress("abb").Dump();
	
	Compress("abbc").Dump();
	
	Compress("aaa").Dump();
}

private static string Compress(string value)
{
	if (string.IsNullOrEmpty(value))
	{
		return string.Empty;
	}
	var result = new StringBuilder();
	
	int counter = 0;
	for (int i = 0; i < value.Length; i++)
	{
		counter++;

		if (i == 0)
		{
			continue;
		}

		if (value[i] != value[i - 1])
		{
			result.Append(counter - 1);
			result.Append(value[i - 1]);
			counter = 1;
		}
	}
	result.Append(counter);
	result.Append(value[value.Length - 1]);
	
	return result.ToString();
}
