<Query Kind="Program" />

void Main()
{
	//LengthOfLongestSubstringKDistinct("eceba", 2).Dump();
	//LengthOfLongestSubstringKDistinct("ab", 1).Dump();
	LengthOfLongestSubstringKDistinct("cccdaba", 3).Dump();
}


public int LengthOfLongestSubstringKDistinct(string s, int k)
{
	var cache = new Dictionary<char, int>();
	int left = 0;
	int result = 0;
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
		while (cache.Count > k)
		{
			char leftChar = s[left];
			if (cache.ContainsKey(leftChar))
			{
				cache[leftChar]--;
				if (cache[leftChar] == 0)
				{
					cache.Remove(leftChar);
				}
			}
			left++;
		}
		result = Math.Max(result, i - left + 1);
	}
	return result;
}

