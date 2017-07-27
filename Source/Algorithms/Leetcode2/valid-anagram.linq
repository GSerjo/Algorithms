<Query Kind="Program" />

void Main()
{
	IsAnagram("anagram", "nagaram").Dump();
	IsAnagram("rat", "car").Dump();
}

private static bool IsAnagram(string s, string t)
{
	if (s == t)
	{
		return true;
	}
	if (s == null || t == null)
	{
		return false;
	}
	if (s.Length != t.Length)
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
	foreach (var item in t)
	{
		if (!cache.ContainsKey(item))
		{
			return false;
		}
		cache[item]--;
		if (cache[item] < 0)
		{
			return false;
		}
	}
	return true;
}
