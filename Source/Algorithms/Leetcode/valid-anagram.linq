<Query Kind="Program" />

// https://leetcode.com/problems/valid-anagram/

void Main()
{
	IsAnagram("anagram", "nagaram").Dump();
	IsAnagram("rat", "car").Dump();
}

private static bool IsAnagram(string first, string second)
{
	if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
	{
		return true;
	}
	if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
	{
		return false;
	}

	if (first.Length != second.Length)
	{
		return false;
	}
	
	var array1 = first.ToCharArray().OrderBy(x=>x).ToArray();
	var array2 = second.ToCharArray().OrderBy(x=>x).ToArray();
	
	for (int i = 0; i < array1.Length; i++)
	{
		if (array1[i] != array2[i])
		{
			return false;
		}
	}
	return true;
}
