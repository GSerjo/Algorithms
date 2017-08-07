<Query Kind="Program" />

void Main()
{
	NumberOfPatterns(1, 1).Dump();
}
/*
| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |
*/
public int NumberOfPatterns(int m, int n)
{
	var skip = CreateSkipTable();
	var result = 0;
	var visited = new bool[10];
	
	for (int i = m; i <= n; i++)
	{
		result += Count(visited, skip, 1, i - 1) * 4;
		result += Count(visited, skip, 2, i - 1) * 4;
		result += Count(visited, skip, 5, i - 1);
	}
	
	return result;
}

private int Count(bool[] visited, int[,] skip, int current, int remain)
{
	if (remain < 0)
	{
		return 0;
	}
	if (remain == 0)
	{
		return 1;
	}
	
	visited[current] = true;
	var result = 0;
	
	for (int i = 1; i <= 9; i++)
	{
		var isSkipViseted = visited[skip[current, i]];
		if (!visited[i] && (skip[current, i] == 0 || isSkipViseted))
		{
			result += Count(visited, skip, i, remain - 1);
		}
	}
	visited[current] = false;
	return result;
}

private int[,] CreateSkipTable()
{
	var skip = new int[10, 10];
	SetSymmetricSkip(skip, 1, 3, 2);
	SetSymmetricSkip(skip, 1, 7, 4);
	SetSymmetricSkip(skip, 3, 9, 6);
	SetSymmetricSkip(skip, 7, 9, 8);
	
	SetSymmetricSkip(skip, 1, 9, 5);
	SetSymmetricSkip(skip, 4, 6, 5);
	SetSymmetricSkip(skip, 7, 3, 5);
	SetSymmetricSkip(skip, 2, 8, 5);
	
	return skip;
}

private void SetSymmetricSkip(int[,] skip, int row, int column, int skipCell)
{
	skip[row, column] = skipCell;
	skip[column, row] = skipCell;
}
