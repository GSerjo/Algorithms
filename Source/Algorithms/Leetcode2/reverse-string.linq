<Query Kind="Program" />

void Main()
{
	ReverseString("hello").Dump();
}
public string ReverseString(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return s;
	}
	var lo = 0;
	var hi = s.Length - 1;
	var result = new StringBuilder(s);
	
	while (lo <= hi)
	{
		var dummy = result[lo];
		result[lo] = result[hi];
		result[hi] = dummy;
		lo++;
		hi--;
	}
	return result.ToString();
}
