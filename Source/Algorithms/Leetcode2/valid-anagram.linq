<Query Kind="Program" />

void Main()
{
	
}

public bool IsAnagram(string s, string t)
{
	if(string.Equals(s, t))
	{
		return true;
	}
	if(string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
	{
		return false;
	}
	
	if(s.Length != t.Length
	{
		return false;
	}
	
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
			return false;
		}
		cache[item]--;
		if(cache[item] < 0)
		{
			return false;
		}
	}	
	return true;
}
