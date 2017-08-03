<Query Kind="Program" />

void Main()
{
	IslandPerimeter(new int[4, 4] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 }}).Dump();
}

private static int IslandPerimeter(int[,] grid)
{
	if (grid.GetLength(0) == 0)
	{
		return 0;
	}
	
	var result = 0;
	for (int i = 0; i < grid.GetLength(0); i++)
	{
		for (int j = 0; j < grid.GetLength(1); j++)
		{
			if (grid[i, j] == 1)
			{
				result += 4;
				if (i > 0 && grid[i - 1, j] == 1)
				{
					result -= 2;
				}
				if (j > 0 && grid[i, j - 1] == 1)
				{
					result -= 2;
				}
			}

		}
	}
	return result;
}