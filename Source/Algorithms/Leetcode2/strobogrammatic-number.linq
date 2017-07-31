<Query Kind="Program" />

void Main()
{
	IsStrobogrammatic("818").Dump();
	IsStrobogrammatic("8").Dump();
	IsStrobogrammatic("6").Dump();
}

private static bool IsStrobogrammatic(string num)
{
	if (string.IsNullOrEmpty(num))
	{
		return false;
	}
	var cache = new Dictionary<char, char> { { '6', '9' }, {'9', '6'}, { '0', '0' }, { '1', '1' }, {'8','8'}};
	var lo = 0;
	var hi = num.Length - 1;
	
	while (lo <= hi)
	{
		if (!cache.ContainsKey(num[lo]))
		{
			return false;
		}
		if (cache[num[lo]] != num[hi])
		{
			return false;
		}
		lo++;
		hi--;
	}
	return true;	
}
