<Query Kind="Program" />

/*

Reverse the words in the sentence

*/

void Main()
{
	Reverse("The quick brown fox jumped").Dump();
}

private static string Reverse(string input)
{
	if(string.IsNullOrWhiteSpace(input))
	{
		return input;
	}
	var result = new StringBuilder(input.Length);
	var position = 0;
	foreach (var item in input)
	{
		if(item == ' ')
		{
			position = 0;
			result.Insert(position, ' ');
			continue;
		}
		result.Insert(position, item);
		position++;
	}
	return result.ToString();
}