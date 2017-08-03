<Query Kind="Program" />

void Main()
{
	//LengthOfLongestSubstringKDistinct("eceba", 2).Dump();
	//LengthOfLongestSubstringKDistinct("ab", 1).Dump();
	LengthOfLongestSubstringKDistinct("cccdaba", 3).Dump();
}

private static int LengthOfLongestSubstringKDistinct(string s, int k)
{
	int[] count = new int[256];
	int dummy = 0;
	var i = 0;
	var result = 0;
	for (int j = 0; j < s.Length; j++)
	{
		if (count[s[j]]++ == 0)
		{
			dummy++;
		}
		if (dummy > k)
		{
			while (--count[s[i++]] > 0);
			dummy--;
		}
		result = Math.Max(result, j - i + 1);
	}
	return result;
}

