<Query Kind="Program" />

void Main()
{
	GenerateParens(3).Dump();
}

private static List<string> GenerateParens(int value)
{
	if (value == 0)
	{
		return new List<string>();
	}
	if (value == 1)
	{
		return new List<string> { "()"};
	}
	var dummy = new HashSet<string>();
	dummy.Add("()");
	
	var result = new HashSet<string>();
	
	for (int i = 2; i <= value; i++)
	{
		foreach (var item in dummy)
		{
			for (int j = 0; j < item.Length; j++)
			{
				if (j == 0)
				{
					var newItem = item.Insert(j, "()");
					if (!result.Contains(newItem))
					{
						result.Add(newItem);
					}
				}
				if (item[j] == '(')
				{
					var newItem = item.Insert(j + 1, "()");
					if (!result.Contains(newItem))
					{
						result.Add(newItem);
					}
				}
			}
		}
		dummy = result;
		result = new HashSet<string>();
	}
	return dummy.ToList();
}