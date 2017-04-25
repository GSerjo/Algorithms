<Query Kind="Program" />

// https://leetcode.com/problems/longest-common-prefix/

void Main()
{
	LongestCommonPrefix(new[] {"", "b"}).Dump();
	LongestCommonPrefix(new[] {"aaab,", "aaaabc", "aaa"}).Dump();

	LongestCommonPrefix2(new[] { "", "b" }).Dump();
	LongestCommonPrefix2(new[] { "aaab,", "aaaabc", "aaa" }).Dump();

}

private static string LongestCommonPrefix2(string[] array)
{
	if (array == null || array.Length == 0)
	{
		return string.Empty;
	}
	if (array.Length == 1)
	{
		return array[0];
	}
	Array.Sort(array);
	var first = array[0].ToCharArray();
	var last = array[array.Length - 1].ToCharArray();
	
	var result = new StringBuilder();
	var length = Math.Min(first.Length, last.Length);
	for (int i = 0; i < length; i++)
	{
		if (first[i] == last[i])
		{
			result.Append(first[i]);
		}
		else
		{
			return result.ToString();
		}
	}
	return result.ToString();
}

private static string LongestCommonPrefix(string[] array)
{
	var result = string.Empty;
	if (array == null || array.Length == 0)
	{
		return result;
	}
	if (array.Length == 1)
	{
		return array[0];
	}
	for (int i = 0; i < array.Length - 1; i++)
	{
		var prefix = CommonPrefix(array[i], array[i + 1]);
		if (string.IsNullOrWhiteSpace(prefix))
		{
			return string.Empty;
		}
		if (i == 0)
		{
			result = prefix;
		}
		if (prefix.Length < result.Length)
		{
			result = prefix;
		}
	}
	return result;
}

private static string CommonPrefix(string value1, string value2)
{
	if (string.Equals(value1, value2, StringComparison.Ordinal))
	{
		return value1;
	}
	if (string.IsNullOrWhiteSpace(value1) || string.IsNullOrWhiteSpace(value2))
	{
		return string.Empty;
	}	
	var lenght = Math.Min(value1.Length, value2.Length);
	for (int i = 0; i < lenght; i++)
	{
		if (value1[i] != value2[i])
		{
			return value1.Substring(0, i);
		}
	}
	return value1.Substring(0, lenght);
}
