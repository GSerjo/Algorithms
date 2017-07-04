<Query Kind="Program" />

void Main()
{
	var word1 = Console.ReadLine();
	var word2 = Console.ReadLine();

//	var word1 = "short";
//	var word2 = "ports";
	
	Console.WriteLine(Count(word1, word2));
}

private int Count(string a, string b)
{
	if (string.Equals(a, b, StringComparison.Ordinal))
	{
		return 0;
	}
	
	var matrix = new int[a.Length + 1, b.Length + 1];
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		matrix[i, 0] = i;
	}
	
	for (int i = 0; i < matrix.GetLength(1); i++)
	{
		matrix[0, i] = i;
	}

	for (int i = 1; i < matrix.GetLength(0); i++)
	{
		for (int j = 1; j < matrix.GetLength(1); j++)
		{
			var left = matrix[i, j - 1] + 1;
			var up = matrix[i - 1, j] + 1;
			var min1 = Math.Min(left, up);
			
			var diff = a[i - 1] == b[j - 1] ? 0 : 1;
			
			var min = Math.Min(min1, matrix[i - 1, j - 1] + diff);
			matrix[i, j] = min;
		}
	}
	
	return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
}