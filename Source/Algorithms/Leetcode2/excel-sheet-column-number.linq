<Query Kind="Program" />

void Main()
{
	TitleToNumber("AAA").Dump();
}

public int TitleToNumber(string s)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		return 0;
	}
	int baseNumber = 26;
	var result = 0;
	
	for (int i = 0; i < s.Length; i++)
	{
		var index = s.Length - 1 - i;
		if (index == 0)
		{
			result = result + s[i] - 'A' + 1;
		}
		else
		{
			result = result + (int)Math.Pow(baseNumber, index)*(s[i] - 'A' + 1);
		}
	}
	
	return result;
}
