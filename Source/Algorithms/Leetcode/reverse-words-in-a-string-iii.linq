<Query Kind="Program" />

/*
 https://leetcode.com/problems/reverse-words-in-a-string-iii/
 
Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
 
*/

void Main()
{
	ReverseWords("Let's take LeetCode contest").Dump();
	ReverseWords("123").Dump();
	ReverseWords("12 23 34").Dump();
	ReverseWords("hehhhhhhe").Dump();

	ReverseWords2("Let's take LeetCode contest").Dump();
	ReverseWords2("123").Dump();
	ReverseWords2("12 23 34").Dump();
	ReverseWords2("hehhhhhhe").Dump();

}

private static string ReverseWords2(string value)
{
	if (string.IsNullOrWhiteSpace(value))
	{
		return value;
	}
	var result = new StringBuilder(value);
	var startIndex = 0;
	for (int i = 0; i < result.Length; i++)
	{
		if (result[i] == ' ')
		{
			ReverseString(result, startIndex, i - 1);
			startIndex = i + 1;
		}
	}
	ReverseString(result, startIndex, value.Length - 1);
	return result.ToString();
}

private static string ReverseWords(string value)
{
	if (string.IsNullOrWhiteSpace(value))
	{
		return value;
	}
	var result = new StringBuilder(value);
	var startIndex = 0;
	while (true)
	{
		var endIndex = value.IndexOf(' ', startIndex);
		if (endIndex < 0)
		{
			ReverseString(result, startIndex, value.Length - 1);
			break;
		}
		ReverseString(result, startIndex, endIndex - 1);
		startIndex = endIndex + 1;
	}
	return result.ToString();
}

private static void ReverseString(StringBuilder value, int lo, int hi)
{
	while (lo < hi)
	{
		var temp = value[lo];
		value[lo] = value[hi];
		value[hi] = temp;
		lo++;
		hi--;
	}
}
