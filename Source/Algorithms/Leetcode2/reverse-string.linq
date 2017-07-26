<Query Kind="Program" />

void Main()
{
	ReverseString("hello").Dump();
}

public static string ReverseString(string s)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		return s;
	}
	int lo = 0;
	int hi = s.Length - 1;
	var result = new StringBuilder(s);
	while (lo < hi)
	{
		var dummy = result[lo];
		result[lo] = result[hi];
		result[hi] = dummy;
		
		hi--;
		lo++;
	}
	return result.ToString();
}
