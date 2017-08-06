<Query Kind="Program" />

void Main()
{
	char[,] grid = new char[,] { {'0', 'E', '0', '0'}, {'E', '0', 'W', 'E'}, {'0', 'E', '0', '0'}};
	
	MaxKilledEnemies(grid).Dump();
}

public int MaxKilledEnemies(char[,] grid)
{
	var columnE = new int[grid.GetLength(1)];
	var result = 0;
	
	for (int i = 0; i < grid.GetLength(0); i++)
	{
		var rowL = 0;
		var rowR = -1;
		
		for (int j = 0; j < grid.GetLength(1); j++)
		{
			var symbol = grid[i, j];

			if (symbol == 'E')
			{
				rowL++;
				rowR--;
			}
			else if (symbol == 'W')
			{
				rowL = 0;
				rowR = -1;
			}
			else
			{
				rowR = GetRowE(grid, i, j, rowR);
				UpdateColumnE(grid, i, j, columnE);
				var rowE = rowL + rowR;
				result = Math.Max(result, rowE + columnE[j]);
			}
		}
	}
	return result;
}

private void UpdateColumnE(char[,] grid, int row, int column, int[] columnE)
{
	while (true)
	{
		row--;
		if (row < 0)
		{
			row = 0;
			break;
		}
		var symbol = grid[row, column];
		if (symbol == '0')
		{
			return;
		}
		else if (symbol == 'W')
		{
			row++;
			break;
		}
	}
	
	columnE[column] = 0;
	for (int i = row; i < grid.GetLength(0); i++)
	{
		var symbol = grid[i, column];
		if (symbol == 'W')
		{
			return;
		}
		else if (symbol == 'E')
		{
			columnE[column]++;
		}
	}
}

private int GetRowE(char[,] grid, int row, int column, int rowR)
{
	if (rowR >= 0)
	{
		return rowR;
	}
	
	rowR = 0;
	while (true)
	{
		column++;
		if (column >= grid.GetLength(1))
		{
			break;
		}
		var dummy = grid[row, column];
		if (dummy == 'E')
		{
			rowR++;
		}
		else if (dummy == 'W')
		{
			break;
		}
	}
	return rowR;
}
