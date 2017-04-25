<Query Kind="Program" />

//https://leetcode.com/problems/reverse-string/

void Main()
{
	ReverseString("1234").Dump();
	ReverseString("123").Dump();
}

private static string ReverseString(string value)
{
	if (string.IsNullOrWhiteSpace(value))
	{
		return value;
	}
	var result = new StringBuilder(value);
	var lo = 0;
	var hi = value.Length - 1;
	while (lo < hi)
	{
		var temp = result[lo];
		result[lo] = result[hi];
		result[hi] = temp;
		lo++;
		hi--;
	}
	return result.ToString();
}
