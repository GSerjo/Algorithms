<Query Kind="Program" />

void Main()
{
	LongestCommonPrefix(new List<string> {"geeksforgeeks", "geeks", "geek", "geezer"}).Dump();
}

private static string LongestCommonPrefix(List<string> list)
{
	if (list == null || list.Count == 0)
	{
		return string.Empty;
	}
	if (list.Count == 1)
	{
		return list[0];
	}
	list.Sort();
	
	var first = list[0];
	var last = list[list.Count - 1];
	
	var length = Math.Min(first.Length, last.Length);
	
	var result = new StringBuilder();
	for (int i = 0; i < length; i++)
	{
		if (first[i] != last[i])
		{
			break;
		}
		result.Append(first[i]);
	}
	return result.ToString();
}
