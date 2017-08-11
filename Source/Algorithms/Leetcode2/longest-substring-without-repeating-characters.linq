<Query Kind="Program" />

void Main()
{
	LengthOfLongestSubstring("abcabcbb").Dump();
	LengthOfLongestSubstring("bbbbb").Dump();
}

public int LengthOfLongestSubstring(string s)
{
	if (string.IsNullOrEmpty(s))
	{
		return 0;
	}
	var lo = 0;
	var current = 0;
	var result = 0;
	var cache = new HashSet<char>();

	while (current < s.Length)
	{
		var item = s[current];
		if (cache.Contains(item))
		{
			while (cache.Contains(item))
			{
				cache.Remove(s[lo++]);
			}
		}
		cache.Add(item);
		result = Math.Max(current - lo + 1, result);
		current++;
	}
	return result;
}
