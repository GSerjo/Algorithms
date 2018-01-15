<Query Kind="Program" />

void Main()
{
	
}

public string LongestCommonPrefix(string[] strs)
{
	if(strs == null || strs.Length == 0)
	{
		return string.Empty;
	}
	if(strs.Length == 1)
	{
		return strs[0];
	}
	Array.Sort(strs);
	var first = strs[0];
	var last = strs[strs.Length - 1];
	
	var length = Math.Min(first.Length, last.Length);
	var result = new StringBuilder();
	
	for (int i = 0; i < length; i++)
	{
		if(first[i] != last[i])
		{
			break;
		}
		result.Append(first[i]);
	}
	return result.ToString();
}
