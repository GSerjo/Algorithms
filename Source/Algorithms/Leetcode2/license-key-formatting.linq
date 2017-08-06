<Query Kind="Program" />

void Main()
{
	LicenseKeyFormatting("--a-a-a-a--", 2).Dump();
}

private string LicenseKeyFormatting(string s, int k)
{
	if (string.IsNullOrEmpty(s))
	{
		return string.Empty;
	}
	var result = new StringBuilder();
	var counter = 0;
	for (int i = s.Length - 1; i >= 0; i--)
	{
		if (s[i] == '-')
		{
			continue;
		}
		if (counter > k)
		{
			result.Insert(1, "-");
			counter = 1;
		}
		if (char.IsLower(s[i]))
		{
			result.Insert(0, s[i].ToString().ToUpper());
		}
		else
		{
			result.Insert(0, s[i]);
		}
		counter++;
	}
	if (counter > k)
	{
		result.Insert(1, "-");
		counter = 1;
	}
	return result.ToString();
}
