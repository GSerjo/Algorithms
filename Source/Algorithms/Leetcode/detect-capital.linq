<Query Kind="Program" />

/*

https://leetcode.com/problems/detect-capital
Given a word, you need to judge whether the usage of capitals in it is right or not.

We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital if it has more than one letter, like "Google".
Otherwise, we define that this word doesn't use capitals in a right way.

*/

void Main()
{
	DetectCapitalUse("USA").Dump();
	DetectCapitalUse("leetcode").Dump();
	DetectCapitalUse("Google").Dump();
	DetectCapitalUse("GooglE").Dump();
}


private static bool DetectCapitalUse(string word)
{
	if (string.IsNullOrWhiteSpace(word))
	{
		return false;
	}
	var upperCaseCount = 0;
	for (int i = 0; i < word.Length; i++)
	{
		if (char.IsUpper(word[i]))
		{
			upperCaseCount++;
		}
	}
	if (upperCaseCount == word.Length || upperCaseCount == 0)
	{
		return true;
	}
	if (upperCaseCount == 1 && char.IsUpper(word[0]))
	{
		return true;
	}
	return false;
}

