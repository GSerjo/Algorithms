<Query Kind="Program" />

void Main()
{
	CharacterReplacement("ABAB", 2).Dump();
	CharacterReplacement("AABABBA", 1).Dump();
}

private int CharacterReplacement(string s, int k)
{
	var result = 0;
	var cache = new Dictionary<char, int>();
	var left = 0;

	for (int i = 0; i < s.Length; i++)
	{
		if (cache.ContainsKey(s[i]))
		{
			cache[s[i]]++;
		}
		else
		{
			cache[s[i]] = 1;
		}
		while (DistinctChars(cache) > k)
		{
			if (cache[s[left]] == 0)
			{
				cache.Remove(s[left]);
			}
			else
			{
				cache[s[left]]--;
			}
			left++;
		}
		result = Math.Max(result, i - left + 1);
	}
	return result;
}

private int DistinctChars(Dictionary<char, int> cache)
{
	var sum = 0;
	var max = 0;
	
	foreach (var item in cache.Values)
	{
		max = Math.Max(max, item);
		sum += item;
	}
	return sum - max;
}
