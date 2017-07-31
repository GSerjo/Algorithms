<Query Kind="Program" />

void Main()
{
	ReverseWords("Let's take LeetCode contest").Dump();
}

private static string ReverseWords(string s)
{
	if (string.IsNullOrEmpty(s))
	{
		return s;
	}
	var result = new StringBuilder(s);

	var lo = 0;
	
	for (int i = 0; i < result.Length; i++)
	{
		if (result[i] == ' ')
		{
			Reverse(result, lo, i - 1);
			lo = i + 1;
		}
	}
	if (lo < result.Length)
	{
		Reverse(result, lo, result.Length - 1);
	}
	return result.ToString();
}

private static void Reverse(StringBuilder s, int lo, int hi)
{
	while (lo <= hi)
	{
		var dummy = s[lo];
		s[lo] = s[hi];
		s[hi] = dummy;
		lo++;
		hi--;
	}
}
