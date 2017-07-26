<Query Kind="Program" />

void Main()
{
	FirstUniqChar("loveleetcode").Dump();
}

public static int FirstUniqChar(string s)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		return -1;
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
	
	for (int i = 0; i < s.Length; i++)
	{
		if (cache[s[i]] == 1)
		{
			return i;
		}
	}
	return -1;
}
