<Query Kind="Program" />

void Main()
{
	LengthOfLongestSubstring("abcabcbb").Dump();
}
/*
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.

Given "bbbbb", the answer is "b", with the length of 1.

Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/

public int LengthOfLongestSubstring(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return 0;
	}
	var cache = new HashSet<char>();
	var lo = 0;
	var current = 0;
	var result = 0;
	
	while(current < s.Length)
	{
		var item = s[current];
		
		if(cache.Contains(item))
		{
			while (cache.Contains(item))
			{
				cache.Remove(s[lo++]);
			}
		}
		cache.Add(item);
		result = Math.Max(result, current - lo + 1);
		current++;
	}
	return result;
}
