<Query Kind="Program" />

void Main()
{
	//WordsTyping(new[] {"hello", "world"}, 2, 8).Dump();
	//WordsTyping(new[] {"a", "bcd", "e"}, 3, 6).Dump();
	WordsTyping(new[] {"I", "had", "apple", "pie"}, 4, 5).Dump();
}

private int WordsTyping(string[] sentence, int rows, int cols)
{
	var nextIndex = new int[sentence.Length];
	var times = new int[sentence.Length];
	for (int i = 0; i < sentence.Length; i++)
	{
		var used = 0;
		var wordId = i;
		var time = 0;
		while (used + sentence[wordId].Length <= cols)
		{
			used += sentence[wordId++].Length + 1;
			if (wordId == sentence.Length)
			{
				wordId = 0;
				time++;
			}
		}
		nextIndex[i] = wordId;
		times[i] = time;
	}
	var result = 0;
	var next = 0;
	for (int i = 0; i < rows; i++)
	{
		result += times[next];
		next = nextIndex[next];
	}
	return result;
}