<Query Kind="Program" />

void Main()
{
	AddBoldTag("abcxyz123", new[] { "abc", "123" }).Dump();
	AddBoldTag("aaabbcc", new[] { "aaa", "aab", "bc"}).Dump();
}

private string AddBoldTag(string s, string[] dict)
{
	if (dict == null || dict.Length == 0)
	{
		return s;
	}
	var bold = new bool[s.Length];
	
	foreach (var item in dict)
	{
		int index = 0;

		while (index >= 0)
		{
			index = s.IndexOf(item, index);
			if (index < 0)
			{
				break;
			}
			for (int i = index; i < index + item.Length; i++)
			{
				bold[i] = true;
			}
			index++;
		}
	}
	
	var result = new StringBuilder(s);
	
	var start = -1;
	var shift = 0;
	for (int i = 0; i < bold.Length; i++)
	{
		if (start == -1 && bold[i])
		{
			start = i == 0 ? 0 : i;
			result.Insert(start + shift, "<b>");
			shift += 3;
		}
		if (i > 0 && !bold[i] && bold[i - 1])
		{
			result.Insert(i + shift, "</b>");
			start = -1;
			shift += 4;
		}
	}

	if (start >= 0)
	{
		result.Append("</b>");
	}
	
	return result.ToString();
}
