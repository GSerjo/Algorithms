<Query Kind="Program" />

// https://leetcode.com/problems/isomorphic-strings/

void Main()
{
	// IsIsomorphic("egg", "add").Dump();
	IsIsomorphic("ab", "aa").Dump();
}

private static bool IsIsomorphic(string wordA, string wordB)
{
	if (wordA.Length != wordB.Length)
	{
		return false;
	}
	
	var mapA = new Dictionary<char, char>();
	var mapB = new Dictionary<char, char>();
	
	for (int i = 0; i < wordA.Length; i++)
	{
		if (mapA.ContainsKey(wordA[i]) == false && mapB.ContainsKey(wordB[i]) == false)
		{
			mapA[wordA[i]] = wordB[i];
			mapB[wordB[i]] = wordA[i];
			continue;
		}
		var mapAtoB = mapA.ContainsKey(wordA[i]) && mapA[wordA[i]] == wordB[i];
		var mapBtoA = mapB.ContainsKey(wordB[i]) && mapB[wordB[i]] == wordA[i];
		
		if (mapAtoB != true || mapBtoA != true)
		{
			return false;
		}
	}
	return true;
}