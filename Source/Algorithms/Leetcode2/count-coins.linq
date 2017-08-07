<Query Kind="Program" />

void Main()
{
	Count(6, new[] {1, 3, 5, 10}).Dump();
}

private int Count(int n, int[] coins)
{
	if (n == 0 || coins == null || coins.Length == 0)
	{
		return 0;
	}
	
	var cache = new Dictionary<int, int>();
	cache[0] = 1;
	cache[1] = 1;
	cache[2] = 1;
	
	for (int i = 3; i <= n; i++)
	{
		var result = 0;
		for (int j = 0; j < coins.Length; j++)
		{
			
			if (coins[j] <= i)
			{
				result += cache[i - coins[j]];
			}
			else
			{
				break;
			}
		}
		cache[i] = result;
	}
	return cache[n];
}
