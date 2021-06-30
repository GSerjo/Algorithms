<Query Kind="Program" />

void Main()
{
	ReverseString("1234").Dump();
}

private static string ReverseString(string value)
{
	if(string.IsNullOrEmpty(value))
	{
		return value;
	}
	
	var lo = 0;
	var hi = value.Length - 1;
	var builder = new StringBuilder(value);
	
	while(lo < hi)
	{
		var temp = builder[lo];
		builder[lo] = builder[hi];
		builder[hi] = temp;
		lo++;
		hi--;
	}
	return builder.ToString();
}


