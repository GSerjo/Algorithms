<Query Kind="Program" />

void Main()
{
	FindTheDifference("abcd", "abcde").Dump();
}

public char FindTheDifference(string s, string t)
{
	var cache = new Dictionary<char, int>();
	foreach (var item in s)
	{
		if(cache.ContainsKey(item))
		{
			cache[item]++;
		}
		else
		{
			cache[item] = 1;
		}
	}
	foreach (var item in t)
	{
		if(cache.ContainsKey(item) == false)
		{
			return item;
		}
		cache[item]--;
		if(cache[item] < 0)
		{
			return item;
		}
	}
	throw new ArgumentException();
}
