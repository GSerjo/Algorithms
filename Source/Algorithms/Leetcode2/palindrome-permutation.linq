<Query Kind="Program" />

void Main()
{
	CanPermutePalindrome("aabbccc").Dump();
}

private static bool CanPermutePalindrome(string s)
{
	if (string.IsNullOrEmpty(s))
	{
		return false;
	}
	var cache = new Dictionary<char, int>();
	foreach (var item in s)
	{
		if (cache.ContainsKey(item))
		{
			cache[item]++;
		}
		else
		{
			cache[item] = 1;
		}
	}
	var result = 0;
	foreach (var item in cache.Keys)
	{
		var dummy = cache[item] % 2;
		result += dummy;
	}
	return result <= 1;
}
