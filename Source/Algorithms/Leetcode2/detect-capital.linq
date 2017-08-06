<Query Kind="Program" />

void Main()
{
	DetectCapitalUse("USA").Dump();
	DetectCapitalUse("FlaG").Dump();
	DetectCapitalUse("erT").Dump();
	DetectCapitalUse("eT").Dump();
}

public bool DetectCapitalUse(string word)
{
	if (string.IsNullOrEmpty(word))
	{
		return false;
	}
	var first = char.IsUpper(word[0]);
	var second = false;
	for (int i = 1; i < word.Length; i++)
	{
		if (i == 1)
		{
			second = char.IsUpper(word[i]);
		}
		if (first == false && second != false)
		{
			return false;
		}
		else
		{
			if (second != char.IsUpper(word[i]))
			{
				return false;
			}
		}
	}
	
	return true;
}
