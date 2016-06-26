<Query Kind="Program" />

// https://leetcode.com/problems/excel-sheet-column-number/

void Main()
{
	TitleToNumber("AB").Dump();
}

private static int TitleToNumber(string column)
{
	var abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
	var cache = new Dictionary<char, int>();
	
	for (int i = 0; i < abc.Length; i++)
	{
		cache.Add(abc[i], i+1);
	}
	
	var columns = column.Trim().ToUpper().ToCharArray();

	var result = 0;
	for (int i = 0; i < columns.Length; i++)
	{
		var pow = columns.Length - i - 1;
		result += cache[columns[i]]*(int)Math.Pow(26, pow);
	}
	
	return result;
}
