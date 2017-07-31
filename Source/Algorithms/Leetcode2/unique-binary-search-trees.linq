<Query Kind="Program" />

void Main()
{
	
}

private static int NumTrees(int n)
{
	int[] dummy = new int[n + 1];
	dummy[0] = 1;
	dummy[1] = 1;
	for (int i = 2; i <= n; i++)
	{
		for (int root = 1; root <= i; root++)
		{
			dummy[i] += dummy[i - root] * dummy[root - 1];
		}
	}
	return dummy[n];
}
