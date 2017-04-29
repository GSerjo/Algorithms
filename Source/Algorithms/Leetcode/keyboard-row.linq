<Query Kind="Program" />

/*
https://leetcode.com/problems/keyboard-row/

*/

void Main()
{
	FindWords(new[]{"Hello", "Alaska", "Dad", "Peace"}).Dump();
}

private static string[] FindWords(string[] words)
{
	var alphabet = new[] {"qwertyuiop", "asdfghjkl", "zxcvbnm"};
	var alphabetRow = new Dictionary<char, int>();
	
	for (int i = 0; i < alphabet.Length; i++)
	{
		foreach (var item in alphabet[i])
		{
			alphabetRow[item] = i;
		}
	}
	
	var result = new List<string>();
	for (int i = 0; i < words.Length; i++)
	{
		if(string.IsNullOrWhiteSpace(words[i]))
		{
			continue;
		}
		var word = words[i].ToLower();
		var row = alphabetRow[word[0]];
		var shouldAddRow = true;
		foreach (var item in word)
		{
			var currentRow = alphabetRow[item];
			if(currentRow != row)
			{
				shouldAddRow = false;
				break;
			}
		}
		if(shouldAddRow)
		{
			result.Add(words[i]);
		}
	}
	return result.ToArray();
}