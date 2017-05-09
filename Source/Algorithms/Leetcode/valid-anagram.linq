<Query Kind="Program" />

/*

https://leetcode.com/problems/valid-anagram/

Given two strings s and t, write a function to determine if t is an anagram of s.

For example,
s = "anagram", t = "nagaram", return true.
s = "rat", t = "car", return false.

Note:
You may assume the string contains only lowercase alphabets.

*/

void Main()
{
	IsAnagram("anagram", "nagaram").Dump();
	IsAnagram("rat", "car").Dump();
}

private static bool IsAnagram(string s, string t)
{
	if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
	{
		return string.Equals(s, t);
	}
	if (s.Length != t.Length)
	{
		return false;
	}
	var array1 = s.ToCharArray().OrderBy(x=>x).ToArray();
	var array2 = t.ToCharArray().OrderBy(x=>x).ToArray();
	
	for (int i = 0; i < array1.Length; i++)
	{
		if (array1[i] != array2[i])
		{
			return false;
		}
	}
	return true;
}
